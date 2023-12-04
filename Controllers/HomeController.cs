using ally.DAL;
using ally.Models;
using ally.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ally.Controllers
{
	[Route("")]
	[Route("esas-sehife")]
	[Route("home")]
	[Route("index")]
	public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //HomeVM model = new HomeVM
            //{
            //    UpperCategories = await _context.UpperCategories.ToListAsync(),
            //    Categories = await _context.Categories.ToListAsync(),
            //    SubCategories = await _context.SubCategories.ToListAsync(),
            //};

            //return View(model);

            var categories = await _context.UpperCategories.Include(u => u.Categories).ThenInclude(c => c.SubCategories).ToListAsync();

            return View(categories);
        }
    }
}
