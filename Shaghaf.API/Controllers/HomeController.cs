using Microsoft.AspNetCore.Mvc;
using Shaghaf.Application.Services;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.HomeEntities;
using Shaghaf.Core.Repositories.Contract;
using Shaghaf.Core.Services.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.APIs.Controllers;

namespace Shaghaf.API.Controllers
{
    // The HomeController provides endpoints to manage and retrieve home-related data
    public class HomeController : BaseApiController
    {
        private readonly IHomeService _homeService;
        private readonly IGenericRepository<Home> _homeRepo;

        // Constructor to initialize home service and home repository
        public HomeController(IHomeService homeService, IGenericRepository<Home> homeRepo)
        {
            _homeService = homeService;
            _homeRepo = homeRepo;
        }

        // Endpoint to get home data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Home>>> GetHomeData()
        {
            // Retrieve home data using the home service
            var homeData = await _homeService.GetHomeDataAsync();
            return Ok(homeData);
        }

        // Endpoint to get memberships
        [HttpGet("memberships")]
        public async Task<ActionResult<List<MembershipDto>>> GetMemberships()
        {
            // Retrieve memberships
            var memberships = await _homeService.GetMembershipsAsync();
            return Ok(memberships);
        }

        // Endpoint to get birthdays
        [HttpGet("birthdays")]
        public async Task<ActionResult<List<BirthdayDto>>> GetBirthdays()
        {
            // Retrieve birthdays 
            var birthdays = await _homeService.GetBirthdaysAsync();
           
            return Ok(birthdays);
        }

        // Endpoint to get photo sessions
        [HttpGet("photosessions")]
        public async Task<ActionResult<List<PhotoSessionDto>>> GetPhotoSessions()
        {
            // Retrieve photo sessions asynchronously using the home service
            var photoSessions = await _homeService.GetPhotoSessionsAsync();
            return Ok(photoSessions);
        }

        // Endpoint to get advertisements
        [HttpGet("advertisements")]
        public async Task<ActionResult<List<AdvertisementDto>>> GetAdvertisements()
        {
            // Retrieve advertisements asynchronously using the home service
            var advertisements = await _homeService.GetAdvertisementsAsync();
            return Ok(advertisements);
        }

        // Endpoint to get categories
        [HttpGet("categories")]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories() // Corrected to return List<CategoryDto>
        {
            // Retrieve categories asynchronously using the home service
            var categories = await _homeService.GetCategoriesAsync();
            // Return the retrieved categories
            return Ok(categories);
        }
    }
}
