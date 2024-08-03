using AutoMapper;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.HomeEntities;
using Shaghaf.Core.Entities.RoomEntities;
using Shaghaf.Core.Entities;
using Shaghaf.API.Helpers;
using Shaghaf.Core.Dtos.Shaghaf.Core.DTOs;
using Shaghaf.Core.Entities.BirthdayEntity;
using Shaghaf.Core.Entities.MembershipEntity;
using Shaghaf.Core.Entities.BookingEntities;

namespace Shaghaf.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Home mappings
            CreateMap<Home, HomeDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementDto>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<AdvertisementPictureUrlResolver>());
            CreateMap<Category, CategoryDto>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<CategoryPictureUrlResolver>());
            CreateMap<Membership, MembershipDto>().ReverseMap();
         
            CreateMap<Cake, CakeDto>().ReverseMap();
            CreateMap<Decoration, DecorationDto>().ReverseMap();
            CreateMap<PhotoSession, PhotoSessionDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();

            // Room mappings
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<RoomToCreateDto, Room>()
                .ForMember(dest => dest.Plan, opt => opt.MapFrom(src => Enum.Parse<RoomPlan>(src.Plan)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<RoomType>(src.Type)));
            CreateMap<RoomToCreateDto, RoomDto>().ReverseMap();

            // Booking and BookingDto mappings
            CreateMap<Booking, BookingDto>().ReverseMap();

            // Payment mappings
            CreateMap<PaymentDto, Booking>().ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                                            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                                            .ForMember(dest => dest.SessionId, opt => opt.Ignore())
                                            .ForMember(dest => dest.Discount, opt => opt.Ignore())
                                            .ReverseMap();

           CreateMap<Birthday, BirthdayDto>()
        .ForMember(dest => dest.CakeNames, opt => opt.MapFrom(src => src.Cakes.Select(c => c.Name).ToList()))
        .ForMember(dest => dest.CakePrices, opt => opt.MapFrom(src => src.Cakes.Select(c => c.Price).ToList()))
        .ForMember(dest => dest.DecorationDescriptions, opt => opt.MapFrom(src => src.Decorations.Select(d => d.Description).ToList()))
        .ForMember(dest => dest.DecorationPrices, opt => opt.MapFrom(src => src.Decorations.Select(d => d.Price).ToList()))
        .ForMember(dest => dest.PhotoSessionIds, opt => opt.MapFrom(src => src.PhotoSessions.Select(ps => ps.Id).ToList()))
        .ForMember(dest => dest.PhotoSessionCosts, opt => opt.MapFrom(src => src.PhotoSessions.Select(ps => ps.Cost).ToList()))
        .ForMember(dest => dest.PhotoSessionDurations, opt => opt.MapFrom(src => src.PhotoSessions.Select(ps => ps.Duration).ToList()))
        .ForMember(dest => dest.PhotoSessionDates, opt => opt.MapFrom(src => src.PhotoSessions.Select(ps => ps.Date).ToList()))
        .ForMember(dest => dest.PhotoSessionLocations, opt => opt.MapFrom(src => src.PhotoSessions.Select(ps => ps.Location).ToList()))
        .ReverseMap();
       
        }
    }
}
