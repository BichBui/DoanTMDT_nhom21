using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPhone.Data;
using MvcPhone.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;

namespace MvcPhone.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MvcPhoneContext _context;


        public CustomersController(MvcPhoneContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        public IActionResult Dangky()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dangky([Bind("idUser,tendangnhap,matkhau,hoten,gmail,sdt,diachi,matkhaunhaplai")] Customer customer)
        {
            if (ModelState.IsValid)
            {

                var check = _context.Customers.FirstOrDefault(s => s.gmail == customer.gmail);
                if (check == null)
                {
                    customer.matkhau = GetMD5(customer.matkhau);
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Email đăng ký đã tồn tại.";
                    return View();
                }

            }
            return View(customer);
            
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public IActionResult Dangnhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dangnhap( string email, string password )
        {
           
                var f_password = GetMD5(password);
                var data = await _context.Customers.Where(s => s.gmail.Equals(email) && s.matkhau.Equals(f_password)).ToListAsync();
                if (data.Count() > 0)
                {
                    HttpContext.Session.SetString("hoten", data.FirstOrDefault().hoten);
                    HttpContext.Session.SetString("gmail", data.FirstOrDefault().gmail);
                    HttpContext.Session.SetString("idUser", data.FirstOrDefault().idUser.ToString());
                    ViewBag.Sessiongmail = HttpContext.Session.GetString("gmail");
                    ViewBag.Sessionhoten = HttpContext.Session.GetString("hoten");
                    ViewBag.SessionidUser = HttpContext.Session.GetString("idUser");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Email hoặc mật khẩu sai.";
                    return View();
                }
        
        }



        //Logout
        public ActionResult Dangxuat()
        {
            HttpContext.Session.Clear();//remove session
            return RedirectToAction("Index","Home");
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.idUser == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUser,tendangnhap,matkhau,hoten,gmail,sdt,diachi")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUser,tendangnhap,matkhau,hoten,gmail,sdt,diachi")] Customer customer)
        {
            if (id != customer.idUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.idUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.idUser == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.idUser == id);
        }
    }
}
//var f_password = GetMD5(password);
//var data = _context.Customers.Where(s => s.gmail.Equals(email) && s.matkhau.Equals(f_password)).ToList();
              //  if (data.Count() > 0)
              //  {
               //     //add session
               //     var hoten = data.FirstOrDefault().hoten;
//var gmail = data.FirstOrDefault().gmail;
//var idUser = data.FirstOrDefault().idUser;
//HttpContext.Session.SetString("hoten",hoten);
                  //  HttpContext.Session.SetString("gmail",gmail);
                   // HttpContext.Session.SetString("idUser",idUser.ToString());
                   // ViewBag.Sessiongmail = HttpContext.Session.GetString("gmail");
                   // ViewBag.Sessionhoten = HttpContext.Session.GetString("hoten");
                   // ViewBag.SessionidUser = HttpContext.Session.GetString("idUser");
                   // return RedirectToAction("Index","Home");
               // }
               // else
               // {
                  //  ViewBag.error = "Email hoặc mật khẩu sai.";
                   // return RedirectToAction("Dangnhap");
               // }