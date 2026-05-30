using AutoMapper;
using CouponAPI.Services.Data;
using CouponAPI.Services.Models;
using CouponAPI.Services.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CouponAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private readonly IMapper _mapper;

        public CouponController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        //-----------------------------------------------------------------------------------
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();

                if (!objList.Any())
                {
                    _response.Message = "No coupons availables";
                    _response.Result = new List<CouponDto>();
                }
                else
                {
                    _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
                    _response.Message = $"{objList.Count()} coupons found";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error obtaining coupon: {ex.Message}";
            }
            return _response;
        }

        //-----------------------------------------------------------------------------------
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponId == id);

                // Check if the coupon exists
                if (obj == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Coupon with ID not found {id}";
                    return _response;
                }

                _response.Result = _mapper.Map<CouponDto>(obj);
                _response.Message = "Coupon found successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error searching for coupon: {ex.Message}";
            }
            return _response;
        }

        //-----------------------------------------------------------------------------------
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());

                // Check if the coupon exists
                if (obj == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Coupon with CODE not found {code}";
                    return _response;
                }

                _response.Result = _mapper.Map<CouponDto>(obj);
                _response.Message = "CODE found successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error searching for couponCode: {ex.Message}";
            }
            return _response;
        }

        //-----------------------------------------------------------------------------------
        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();


                _response.Result = _mapper.Map<CouponDto>(obj);
                _response.Message = "Coupon save successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error save for coupon: {ex.Message}";
            }
            return _response;
        }

        //-----------------------------------------------------------------------------------
        [HttpPut]
        public ResponseDto put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();


                _response.Result = _mapper.Map<CouponDto>(obj);
                _response.Message = "Coupon UPDATE successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error updating coupon: {ex.Message}";
            }
            return _response;
        }

        //-----------------------------------------------------------------------------------
        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();

                _response.Message = "Coupon DELETE successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error deleting coupon: {ex.Message}";
            }
            return _response;
        }
    }
}
    
