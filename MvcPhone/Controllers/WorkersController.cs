using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPhone.Data;
using MvcPhone.Models;

namespace MvcPhone.Controllers
{
    public class WorkersController : Controller
    {
        private readonly MvcPhoneContext _context;

        public WorkersController(MvcPhoneContext context)
        {
            _context = context;
        }

        // GET: Workers
        public async Task<IActionResult> Worker()
        {
            return View(await _context.Workers.ToListAsync());
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Manager()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string email, string password)
        {

            
            var data1 = await _context.Workers.Where(s => s.hoten.Equals(email) && s.pass.Equals(password)&& s.phanquyen.Equals("Admin")).ToListAsync();
            if (data1.Count() > 0)
            {
                
                return RedirectToAction("Admin", "Workers");
            }
            else
            {
                var data2 = await _context.Workers.Where(s => s.hoten.Equals(email) && s.pass.Equals(password) && s.phanquyen.Equals("Manager")).ToListAsync();
                if (data2.Count() > 0)
                {
                    return RedirectToAction("Manager", "Workers");
                }
                else
                {
                    ViewBag.error = "Email hoặc mật khẩu sai.";
                    return View();
                }
            }
            

        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .FirstOrDefaultAsync(m => m.STT == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("STT,idNV,hoten,sdt,diachi,ngaysinh,gioitinh,luong,pass,trangthai,phanquyen")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("STT,idNV,hoten,sdt,diachi,ngaysinh,gioitinh,luong,pass,trangthai,phanquyen")] Worker worker)
        {
            if (id != worker.STT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.STT))
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
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .FirstOrDefaultAsync(m => m.STT == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.STT == id);
        }
    }
}
