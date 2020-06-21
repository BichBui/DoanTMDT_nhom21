using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcPhone.Models;
using MvcPhone.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace MvcPhone.Controllers
{
    public class HomeController : Controller
    {

        private readonly MvcPhoneContext _context;

        public HomeController(MvcPhoneContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search1, string search2, string start, string finish)
        {
            
            double a = Convert.ToDouble(start);
            double b = Convert.ToDouble(finish);

            string search = null;
            if (search1 != null)
            { search = search1; }
            else search = search2;
            if (search != null)
            {
                if (start != null)
                {

                    if (finish != null)
                    {

                        ViewData["Message"] = "Kết quả tìm kiếm";
                        var model = from m in _context.Products
                                    where m.gia > a && m.gia < b && m.tenSP.Contains(search)
                                    select m;

                        return View(model);
                    }
                }
                else
                {
                    ViewData["Message"] = "Kết quả tìm kiếm";
                    return View(await _context.Products
                    .Where(p => p.tenSP.Contains(search)).ToListAsync());
                }
            }
            else
            {
                if (start != null)
                {

                    if (finish != null)
                    {

                        ViewData["Message"] = "Kết quả tìm kiếm";
                        var model = from m in _context.Products
                                    where m.gia > a && m.gia < b
                                    select m;

                        return View(model);
                    }
                }
            }
            ViewData["Message"] = "Tất cả sản phẩm";
            return View(await _context.Products.ToListAsync());
        }

        public IActionResult Gioithieu()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
