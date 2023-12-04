using Microsoft.AspNetCore.Mvc;

namespace ally.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
