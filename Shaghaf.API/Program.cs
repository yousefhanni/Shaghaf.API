using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shaghaf.Application.Mappings;
using Shaghaf.Application.Services;
using Shaghaf.Core;
using Shaghaf.Core.Repositories.Contract;
using Shaghaf.Core.Services.Contract;
using Shaghaf.Infrastructure;
using Shaghaf.Infrastructure.Data;
using Shaghaf.Infrastructure.Repositories;
using System.Text.Json.Serialization;
using Stripe;
using Shaghaf.API.Helpers;
using Shaghaf.Infrastructure.Sevices.Implementaion;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Shaghaf.Infrastructure.IdentityData;
using Microsoft.AspNetCore.Identity;
using Shaghaf.Core.Entities.IdentityEntities;
using Shaghaf.Infrastructure.IdentityData.SeedData;
using Shaghaf.Infrastructure.Services;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Shaghaf.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Access configuration
            var configuration = builder.Configuration;

            // Add services to the container    .
            #region Configure Services

            // Configure JSON serialization options
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Handle circular references
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; // Ignore null values
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add DbContext for AppIdentity with SQL Server configuration
            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IRoomService), typeof(RoomService));
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBirthdayService, BirthdayService>();
            builder.Services.AddScoped<IMembershipService, MembershipService>();
            builder.Services.AddScoped<IPhotoSessionService, PhotoSessionService>();
            builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //DI to AuthService
            builder.Services.AddScoped<IAuthService, AuthService>();

            #region Stripe configurations
            // Add Stripe configuration settings
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

            // Retrieve Stripe settings and set the API key
            var stripeSettings = builder.Configuration.GetSection("Stripe").Get<StripeSettings>();
            StripeConfiguration.ApiKey = stripeSettings.SecretKey;
            #endregion


            #region JWT configurations

            // Add Identity services to the application
            // IdentityRole: Represents a role in the ASP.NET Core Identity system
            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            // Bind the JWT configuration section from appsettings.json to the JWT settings class
            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));

            // Configure JWT authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Set default authentication scheme
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Set default challenge scheme
            })
            .AddJwtBearer(options =>
            {
                // Set token validation parameters
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // Validate the issuer
                    ValidateAudience = true, // Validate the audience
                    ValidateLifetime = true, // Validate the token lifetime
                    ValidateIssuerSigningKey = true, // Validate the signing key
                    ValidIssuer = builder.Configuration["Jwt:Issuer"], // Issuer from configuration
                    ValidAudience = builder.Configuration["Jwt:Audience"], // Audience from configuration
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) // Signing key from configuration
                };

                // Configure JWT events
                options.Events = new JwtBearerEvents
                {
                    // Handle authentication failure
                    OnAuthenticationFailed = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize(new { message = "Authentication failed." });
                        return context.Response.WriteAsync(result);
                    },
                    // Handle challenge
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize(new { message = "You are not authorized to access this resource." });
                        return context.Response.WriteAsync(result);
                    }
                };
            });
            #endregion

            #endregion

            var app = builder.Build();
            #region Seed roles
            // Seed roles during application program
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    SeedData.Initialize(services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            #endregion

            #region Configure MiddleWares
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<CustomAuthenticationMiddleware>(); // Use custom authentication middleware

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting(); // Use routing

            app.UseAuthentication(); // Use authentication
            app.UseAuthorization(); // Use authorization

            app.MapControllers(); // Map controllers

            app.Run(); // Run the application
            #endregion
        }
    }
}
