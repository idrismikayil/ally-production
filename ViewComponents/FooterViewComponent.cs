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
    public class FooterViewComponent : ViewComponent
    {
        //private readonly AppDbContext _context;
        //public FooterViewComponent(AppDbContext context)
        //{
        //    _context = context;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
