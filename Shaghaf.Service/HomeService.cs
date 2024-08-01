using AutoMapper;
using Shaghaf.Core.Entities;
using Shaghaf.Core;
using Shaghaf.Core.Entities.HomeEntities;
using Shaghaf.Core.Dtos.Shaghaf.Core.DTOs;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Specifications.Home_Specs;
using Shaghaf.Core.Services.Contract;

namespace Shaghaf.Application.Services
{
    public class HomeService : IHomeService
    {
        // add GetAdvertisementsAsync

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Home>> GetHomeDataAsync()
        {
            var spec = new HomeSpecs();

            
            var home = await _unitOfWork.Repository<Home>().GetAllWithSpecAsync(spec);
            return home;

        }

        public async Task<List<MembershipDto>> GetMembershipsAsync()
        {
            var memberships = await _unitOfWork.Repository<Membership>().GetAllAsync();
            return _mapper.Map<List<MembershipDto>>(memberships);
        }

        public async Task<List<BirthdayDto>> GetBirthdaysAsync()
        {
            var spec = new BirthdaySpecs();

            var birthdays = await _unitOfWork.Repository<Birthday>().GetAllWithSpecAsync(spec);
            return _mapper.Map<List<BirthdayDto>>(birthdays);
        }

        public async Task<List<PhotoSessionDto>> GetPhotoSessionsAsync()
        {
            var photoSessions = await _unitOfWork.Repository<PhotoSession>().GetAllAsync();
            return _mapper.Map<List<PhotoSessionDto>>(photoSessions);
        }

        public async Task<List<AdvertisementDto>> GetAdvertisementsAsync()
        {
            var advertisements = await _unitOfWork.Repository<Advertisement>().GetAllAsync();
            return _mapper.Map<List<AdvertisementDto>>(advertisements);
        }
        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.Repository<Category>().GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
