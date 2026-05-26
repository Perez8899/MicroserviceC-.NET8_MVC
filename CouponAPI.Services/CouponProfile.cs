using AutoMapper;
using CouponAPI.Services.Models;
using CouponAPI.Services.Models.Dto;

namespace CouponAPI.Services
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}