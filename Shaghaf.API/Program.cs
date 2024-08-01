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
using Shaghaf.Service;
using System.Text.Json.Serialization;
using Stripe;
using Shaghaf.API.Helpers;
using Shaghaf.Infrastructure.Sevices.Implementaion;
using Microsoft.OpenApi.Models;

namespace Shaghaf.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.MapType<Newtonsoft.Json.Linq.JObject>(() => new OpenApiSchema { Type = "object" });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IRoomService), typeof(RoomService));
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Add Stripe configuration settings
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

            // Retrieve Stripe settings and set the API key
            var stripeSettings = builder.Configuration.GetSection("Stripe").Get<StripeSettings>();
            if (stripeSettings == null)
            {
                throw new ArgumentNullException("StripeSettings are not configured correctly in appsettings.json.");
            }
            Console.WriteLine($"Stripe Secret Key: {stripeSettings.SecretKey}");
             StripeConfiguration.ApiKey = stripeSettings.SecretKey;
            // Add CORS services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
