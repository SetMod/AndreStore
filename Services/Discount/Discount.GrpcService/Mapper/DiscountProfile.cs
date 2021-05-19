using AutoMapper;
using Discount.GrpcService.Entities;
using Discount.GrpcService.Protos;

namespace Discount.GrpcService.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
