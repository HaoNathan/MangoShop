using AutoMapper;
using MangoShop.Services.CouponApi.Models;
using MangoShop.Services.CouponApi.Models.Dto;

namespace MangoShop.Services.CouponApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Coupon, CouponDto>();
        CreateMap<CouponDto, Coupon>();
    }
}