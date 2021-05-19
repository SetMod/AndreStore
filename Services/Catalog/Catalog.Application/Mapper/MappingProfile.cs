using AutoMapper;
using Catalog.Application.DTO;
using Catalog.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDTO>().ReverseMap();
            CreateMap<Delivery, DeliveryDTO>().ReverseMap();

            //CreateMap<Delivery, DeliveryDTO>()
            //        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //        .ForMember(dest => dest.DeliveryTime, opt => opt.MapFrom(src => src.DeliveryTime))
            //        .ForMember(dest => dest.DeliveryType, opt => opt.MapFrom(src => src.DeliveryType))
            //        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).ReverseMap();
        }

    }
}
