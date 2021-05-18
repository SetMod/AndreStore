using AutoMapper;
using Cart.API.DTO;
using Cart.API.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Cart, CartDTO>().ReverseMap();
            CreateMap<CartItems, CartItemsDTO>().ReverseMap();
            //CreateMap<CartItems, CartItemsDTO>()
            //        .ForMember(ci => ci.Id, cidto => cidto.MapFrom(r => r.Id))
            //        .ForMember(ci => ci.CartId, cidto => cidto.MapFrom(r => r.CartId))
            //        .ForMember(ci => ci.ItemId, cidto => cidto.MapFrom(r => r.ItemId))
            //        .ForMember(ci => ci.Amount, cidto => cidto.MapFrom(r => r.Amount)).ReverseMap();
        }

    }
}
