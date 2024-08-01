using AutoMapper;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.HomeEntities;

namespace Shaghaf.API.Helpers
{
    public class AdvertisementPictureUrlResolver : IValueResolver<Advertisement, AdvertisementDto, string>
    {
        private readonly IConfiguration _configuration;

        public AdvertisementPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Advertisement source, AdvertisementDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))

                return $"{_configuration["ApiBaseUrl"]}/{source.ImageUrl}";

            return string.Empty;
        }
    }
}
