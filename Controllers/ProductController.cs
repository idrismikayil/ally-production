using ally.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ally.Controllers
{
    public class ProductController(AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Index(Guid id)
        {
            var data = await _context.Products
                .Where(p => p.SubCategoryId.Equals(id))
                .OrderBy(p => p.CreatedDate).ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
