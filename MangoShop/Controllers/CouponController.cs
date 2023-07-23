using AutoMapper;
using MangoShop.Services.CouponApi.Data;
using MangoShop.Services.CouponApi.Models;
using MangoShop.Services.CouponApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangoShop.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;

        public CouponController(AppDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
            _response = new ResponseDto { IsSuccess = true, Message = "请求成功" };
        }

        [HttpGet("{id:length(32)}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var coupon = await _db.Coupons.FirstOrDefaultAsync(x => x.Id == id);

                if (coupon == null)
                {
                    _response.Data = null;
                    _response.IsSuccess = false;
                    _response.Message = "未找到此优惠券信息";
                }
                else
                {
                    _response.Data = _mapper.Map<CouponDto>(coupon);
                }
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }

            return Ok(_response);
        }

        [HttpGet("getCoupons")]
        public async Task<IActionResult> GetLists([FromQuery] int pageIndex, int pageSize = 10)
        {
            try
            {
                var coupon = await _db.Coupons.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                _response.Data = _mapper.Map<IEnumerable<CouponDto>>(coupon);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CouponDto model)
        {
            try
            {
                model.Id = Guid.NewGuid().ToString("N");
                var coupon = _mapper.Map<Coupon>(model);
                coupon.CreationTime = DateTime.Now;
                var entity = await _db.Coupons.AddAsync(coupon);
                await _db.SaveChangesAsync();

                _response.Data = entity.Entity;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return Ok(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] CouponDto model)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(model);
                coupon.UpdateTime = DateTime.Now;
                var entity = _db.Coupons.Update(coupon);
                entity.Property(x => x.CreationTime).IsModified = false;
                _response.Data = (await _db.SaveChangesAsync()) > 0;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return Ok(_response);
        }

        [HttpDelete("{id:length(32)}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var coupon = await _db.Coupons.FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (coupon == null)
                {
                    _response.Data = false;
                    _response.IsSuccess = false;
                    _response.Message = "未找到此优惠券信息";
                }
                else
                {
                    //_db.Coupons.Entry(coupon).State = EntityState.Modified;
                    _db.Coupons.Remove(coupon);
                    _response.Data = (await _db.SaveChangesAsync()) > 0;
                }
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return Ok(_response);
        }
    }
}
