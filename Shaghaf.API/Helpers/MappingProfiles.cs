using AutoMapper;
using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Entities.HomeEntities;
using Shaghaf.Core.Entities.RoomEntities;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Dtos.Shaghaf.Core.DTOs;
using Shaghaf.API.Helpers;

namespace Shaghaf.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Home mappings
            CreateMap<Home, HomeDto>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Advertisements, opt => opt.MapFrom(src => src.Advertisements))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories))
                .ReverseMap();
                
            CreateMap<Advertisement, AdvertisementDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<AdvertisementPictureUrlResolver>());
                
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<CategoryPictureUrlResolver>());
                
            CreateMap<Membership, MembershipDto>().ReverseMap();
            CreateMap<Birthday, BirthdayDto>().ReverseMap();
            CreateMap<Cake, CakeDto>().ReverseMap();
            CreateMap<Decoration, DecorationDto>().ReverseMap();
            CreateMap<PhotoSession, PhotoSessionDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();

            // Room mappings
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<RoomToCreateDto, RoomDto>().ReverseMap();
            CreateMap<RoomToCreateDto, Room>().ReverseMap();

            // Booking and BookingDto mappings
            CreateMap<Booking, BookingDto>()
                .ReverseMap();

            //// AdditionalItem and AdditionalItemDto mappings
            //CreateMap<AdditionalItem, AdditionalItemDto>()
            //    .ReverseMap();

            // If you need to map PaymentDto to Booking, ensure this is correct for your use case
            CreateMap<PaymentDto, Booking>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dest => dest.SessionId, opt => opt.Ignore()) // Ignore SessionId if not needed
                .ForMember(dest => dest.Discount, opt => opt.Ignore())  // Ignore Discount if not needed
                .ReverseMap();
        }
    }
}
