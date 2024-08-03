using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.HomeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Services.Contract
{
    public interface IHomeService
    {
        public Task<IReadOnlyList<Home>> GetHomeDataAsync();
       //public Task<List<MembershipDto>> GetMembershipsAsync();
        //public Task<List<BirthdayDto>> GetBirthdaysAsync();
        //public Task<List<PhotoSessionDto>> GetPhotoSessionsAsync();
        public Task<List<AdvertisementDto>> GetAdvertisementsAsync();
        public Task<List<CategoryDto>> GetCategoriesAsync();
    }
}
