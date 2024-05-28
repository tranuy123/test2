using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test2.Models.Entities;
using test2.Models.Mapping;
using test2.Services.HangHoaServices;

namespace test2.Controllers
{
    [Route("[controller]")]
    public class HH_DM_HangHoaController : Controller
    {
        DemoNhaKhoaContext _context;
        IMapper _mapper;
        IHhPhieuNhapServices _services;
        public HH_DM_HangHoaController(DemoNhaKhoaContext context, IMapper mapper, IHhPhieuNhapServices hhPhieuNhapServices)
        {
            _context = context;
            _mapper = mapper;
            _services = hhPhieuNhapServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(HhPhieuNhapMap modelMap)
        { 
            HhPhieuNhap model = _mapper.Map<HhPhieuNhap>(modelMap);
            if (model.Id == 0) 
            {
                var message =  await _services.create(model);
;               
                return Ok(message);
            }
            var message1 = "Thất bại";
            return Ok(message1);
        }

        [HttpPost("update")]
        public async Task<IActionResult> update(HhPhieuNhapMap modelMap)
        {
            HhPhieuNhap model = _mapper.Map<HhPhieuNhap>(modelMap);
            if (model.Id == 0)
            {
                var message = "Thất bại";
              
                return Ok(message);
            }

            var message1 = await _services.update(model);
            return Ok(message1);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> delete(HhPhieuNhapMap modelMap)
        {
            HhPhieuNhap model = _mapper.Map<HhPhieuNhap>(modelMap);
            if (model.Id == 0 || model.Id == null)
            {
                var message = "Thất bại";

                return Ok(message);
            }

            var message1 = await _services.delete(model);
            return Ok(message1);
        }

        [HttpGet("read")]
        public async Task<IActionResult> read()
        {
            var model = await _services.read();
            return Ok(model);
        }

        [HttpGet("readByStrored")]
        public async Task<IActionResult> readByStrored()
        {
            var model = await _services.readByStrored();
            return Ok(model);
        }

        [HttpPost("nangCao1")]
        public async Task<IActionResult> nangCao1(String dateString, String soPhieuNhap)
        {
            var rs = await _services.nangCao1(dateString, soPhieuNhap);
            return Ok(rs);
        }
        [HttpPost("get")]
        public async Task<dynamic> get([FromBody]List<HhDmDonViTinh> donViTinhs)
        {
            return donViTinhs.ToList();
        }
    }
}
