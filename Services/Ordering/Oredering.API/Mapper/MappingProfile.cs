using AutoMapper;
using Ordering.API.DTO;
using Ordering.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Orders, OrdersDTO>().ReverseMap();

            //CreateMap<CartItems, CartItemsDTO>()
            //        .ForMember(ci => ci.Id, cidto => cidto.MapFrom(r => r.Id))
            //        .ForMember(ci => ci.CartId, cidto => cidto.MapFrom(r => r.CartId))
            //        .ForMember(ci => ci.ItemId, cidto => cidto.MapFrom(r => r.ItemId))
            //        .ForMember(ci => ci.Amount, cidto => cidto.MapFrom(r => r.Amount)).ReverseMap();
        }

    }
}
