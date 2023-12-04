using ally.DAL;
using ally.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ally.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public SubCategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(Guid id)
        {
            return View();
        }
    }
}
