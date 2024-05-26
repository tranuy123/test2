using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test2.Models.Entities;

namespace test2.Controllers
{
    [Route("[controller]")]
    public class HH_DM_HangHoaController : Controller
    {
        DemoNhaKhoaContext _context;
        public HH_DM_HangHoaController(DemoNhaKhoaContext context)
        {
            _context = context;
        }
        public async Task<dynamic> Index()
        {
            return View();
        }
        [HttpPost("get")]
        public async Task<dynamic> get([FromBody]List<HhDmDonViTinh> donViTinhs)
        {
            return donViTinhs.ToList();
        }
    }
}
