using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC05.Models;
using Microsoft.AspNetCore;
using HangHoaModel = MVC05.Models.tblHanghoa;

namespace MVC05.Controllers
{
    public class HangHoa : Controller
    {
        private readonly ApplicationDbContext _context;

        public HangHoa(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HangHoa
        public async Task<IActionResult> Index()
        {
            return _context.tblHanghoa != null ?
                        View(await _context.tblHanghoa.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.tblHanghoa'  is null.");
        }

        // GET: HangHoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblHanghoa == null)
            {
                return NotFound();
            }

            var tblHanghoa = await _context.tblHanghoa
                .FirstOrDefaultAsync(m => m.PK_iHanghoaID == id);
            if (tblHanghoa == null)
            {
                return NotFound();
            }

            return View(tblHanghoa);
        }

        // GET: HangHoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HangHoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_iHanghoaID,sTenHang,fGianiemyet,sDacdiem,sXuatxu,sAnhminhhoa")] HangHoaModel tblHanghoa, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "StaticFiles", imageFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                }

                // add file path
                tblHanghoa.sAnhminhhoa = "/StaticFiles/" + imageFile.FileName;


                _context.Add(tblHanghoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblHanghoa);
        }

        // GET: HangHoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblHanghoa == null)
            {
                return NotFound();
            }

            var tblHanghoa = await _context.tblHanghoa.FindAsync(id);
            if (tblHanghoa == null)
            {
                return NotFound();
            }
            return View(tblHanghoa);
        }

        // POST: HangHoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_iHanghoaID,sTenHang,fGianiemyet,sDacdiem,sXuatxu,sAnhminhhoa")] HangHoaModel tblHanghoa)
        {
            if (id != tblHanghoa.PK_iHanghoaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHanghoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblHanghoaExists(tblHanghoa.PK_iHanghoaID))
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
            return View(tblHanghoa);
        }

        // GET: HangHoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblHanghoa == null)
            {
                return NotFound();
            }

            var tblHanghoa = await _context.tblHanghoa
                .FirstOrDefaultAsync(m => m.PK_iHanghoaID == id);
            if (tblHanghoa == null)
            {
                return NotFound();
            }

            return View(tblHanghoa);
        }

        // POST: HangHoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblHanghoa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tblHanghoa'  is null.");
            }
            var tblHanghoa = await _context.tblHanghoa.FindAsync(id);
            if (tblHanghoa != null)
            {
                _context.tblHanghoa.Remove(tblHanghoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblHanghoaExists(int id)
        {
            return (_context.tblHanghoa?.Any(e => e.PK_iHanghoaID == id)).GetValueOrDefault();
        }
    }
}
