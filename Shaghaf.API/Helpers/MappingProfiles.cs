using AutoMapper;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Entities.BirthdayEntity;
using Shaghaf.Core.Entities.HomeEntities;
using Shaghaf.Core.Entities.MembershipEntity;
using Shaghaf.Core.Entities.RoomEntities;
using Shaghaf.API.Helpers;
using Shaghaf.Core.Dtos.Shaghaf.Core.DTOs;
using Shaghaf.Core.Entities;

namespace Shaghaf.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Home mappings
            CreateMap<Home, HomeDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<AdvertisementPictureUrlResolver>());
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<CategoryPictureUrlResolver>());

            // Birthday mappings
            CreateMap<Cake, CakeDto>().ReverseMap();
            CreateMap<Decoration, DecorationDto>().ReverseMap();
            CreateMap<Birthday, BirthdayDto>()
                .ForMember(dest => dest.Cakes, opt => opt.MapFrom(src => src.Cakes))
                .ForMember(dest => dest.Decorations, opt => opt.MapFrom(src => src.Decorations))
                .ReverseMap();
            CreateMap<BirthdayToCreateDto, Birthday>();

            // PhotoSession mappings
            CreateMap<PhotoSessionToCreateDto, PhotoSession>()
                .ForMember(dest => dest.Room, opt => opt.Ignore());
            CreateMap<PhotoSession, PhotoSessionDto>().ReverseMap();

            // Location mappings
            CreateMap<Location, LocationDto>().ReverseMap();

            // Room mappings
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<RoomToCreateDto, Room>()
                .ForMember(dest => dest.Plan, opt => opt.MapFrom(src => Enum.Parse<RoomPlan>(src.Plan)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<RoomType>(src.Type)));
            CreateMap<RoomToCreateDto, RoomDto>().ReverseMap();

            //// Booking mappings;
            CreateMap<BookingToCreateDto, Booking>()
    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<BookingStatus>(src.Status, true)));

            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            // Payment mappings
            CreateMap<PaymentDto, Booking>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dest => dest.SessionId, opt => opt.Ignore())
                .ForMember(dest => dest.Discount, opt => opt.Ignore())
                .ReverseMap();

            // Membership mappings
            CreateMap<Membership, MembershipDto>().ReverseMap();
            CreateMap<MembershipToCreateDto, Membership>();

            //MenuItem mappings 
            CreateMap<MenuItemToCreateDto, MenuItem>()
                  .ForMember(dest => dest.PictureUrl, opt => opt.Ignore());
            CreateMap<MenuItem, MenuItemDto>();
        }
    }
}
