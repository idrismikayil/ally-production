using ally.Models;
//using ally.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ally.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        //private readonly AppDbContext _context;
        //public HeaderViewComponent(AppDbContext context)
        //{
        //    _context = context;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
