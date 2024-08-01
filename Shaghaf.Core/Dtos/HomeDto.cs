namespace Shaghaf.Core.Dtos
{
    namespace Shaghaf.Core.DTOs
    {
        public class HomeDto
        {
            public LocationDto Location { get; set; }
            public string Heading { get; set; }
            public List<AdvertisementDto> Advertisements { get; set; }
            public List<CategoryDto> Categories { get; set; }
        }
    }

}
