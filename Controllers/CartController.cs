using ally.Constants;
using ally.DAL;
using ally.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ally.Controllers
{
    public class CartController(AppDbContext _context,HttpContext _httpContext) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = GetSessionTokenFromCookie(_httpContext);
            var data = await _context.ShoppingCart
                .Where(c => c.Token.Equals(token))
                .ToListAsync();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddItemToCart(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (!product.Equals(null))
            {
                var CartItem = new Cart()
                {
                    Item = product,
                    Quantity = 1
                };
                await _context.AddAsync(CartItem);
                await _context.SaveChangesAsync();
            }
            return View();
        }
        [HttpGet]
        public async Task<int> ReturnNumberOfItemsInCart()
        {
            int quantity = 0;
            var token = GetSessionTokenFromCookie(_httpContext);
            var data = await _context.ShoppingCart
                .Where(c => c.Token.Equals(token))
                .ToListAsync();
            foreach (var item in data)
            {
                quantity += item.Quantity;
            }
            return quantity;
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveItemFromCart(Guid id)
        {
            var data = await _context.ShoppingCart.FirstOrDefaultAsync(i => i.Id.Equals(id)) ?? null;
            if (!data.Equals(null))
            {
                _context.Remove(data);
            }
            await _context.SaveChangesAsync();
            return View();

        }
        private static string GetSessionTokenFromCookie(HttpContext context)
        {
            context.Request.Cookies.TryGetValue(TokenConstant.SessionToken, out string? token);
            return token ?? string.Empty;
        }
    }
}
