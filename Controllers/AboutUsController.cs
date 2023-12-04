using ally.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ally.Controllers
{
    [Route("Haqqimizda")]
    [Route("about-us")]
    public class AboutUsController(AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var about = await _context.AboutUs.FirstOrDefaultAsync();

            return View(about);
        }
    }
}