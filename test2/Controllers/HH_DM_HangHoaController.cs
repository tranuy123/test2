using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test2.Models.Entities;

namespace test2.Controllers
{
    public class HH_DM_HangHoaController : Controller
    {
        DemoNhaKhoaContext _context;
        public HH_DM_HangHoaController(DemoNhaKhoaContext context)
        {
            _context = context;
        }
        public async Task<dynamic> Index()
        {
            var hh = await _context.HhHangHoas
                .Where(x => x.HanSuDung.Value.Date == DateTime.Now.Date)
                .ToListAsync();
            foreach (HhHangHoa h in hh)
            {
                h.HanSuDung = DateTime.Now;
            }
            _context.HhHangHoas.UpdateRange(hh);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
