using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThucTap1.Data;
using ThucTap1.Models;

namespace ThucTap1.Controllers
{
    public class HuongDansController : Controller
    {
        private readonly ThucTap1Context _context;

        public HuongDansController(ThucTap1Context context)
        {
            _context = context;
        }

        // GET: HuongDans
        public async Task<IActionResult> Index()
        {
           
            var huongDans = _context.HuongDan
                                    .Include(h => h.SinhVien)  
                                    .Include(h => h.GiangVien)  
                                    .Include(h => h.DeTai)     
                                    .ToListAsync();

            return _context.HuongDan != null ?
                       View(await huongDans) :
                       Problem("Entity set 'ThucTap1Context.HuongDan' is null.");
        }


        // GET: HuongDans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HuongDan == null)
            {
                return NotFound(); 
            }

            var huongDan = await _context.HuongDan
                .Include(h => h.SinhVien)
                .Include(h => h.GiangVien)
                .Include(h => h.DeTai)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (huongDan == null)
            {
                return NotFound();
            }

            return View(huongDan);
        }

        // GET: HuongDans/Create
        public IActionResult Create()
        {
            ViewBag.SinhVienList = new SelectList(_context.SinhVien, "MaSV", "HoTenSV");
            ViewBag.DeTaiList = new SelectList(_context.DeTai, "MaDT", "TenDT");
            ViewBag.GiangVienList = new SelectList(_context.GiangVien, "MaGV", "HoTenGV");

            return View();
        }


        // POST: HuongDans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]

        public async Task<IActionResult> Create([Bind("MaSV, MaDT, MaGV, KetQua")] HuongDan huongDan)
        {
            if (ModelState.IsValid)
            {
                huongDan.SinhVien = await _context.SinhVien.FindAsync(huongDan.MaSV);
                huongDan.DeTai = await _context.DeTai.FindAsync(huongDan.MaDT);
                huongDan.GiangVien = await _context.GiangVien.FindAsync(huongDan.MaGV);

                _context.Add(huongDan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.SinhVienList = new SelectList(_context.SinhVien, "MaSV", "HoTenSV");
            ViewBag.DeTaiList = new SelectList(_context.DeTai, "MaDT", "TenDT");
            ViewBag.GiangVienList = new SelectList(_context.GiangVien, "MaGV", "HoTenGV");

            return View(huongDan);
        }


        // GET: HuongDans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HuongDan == null)
            {
                return NotFound();
            }

            var huongDan = await _context.HuongDan
                .Include(h => h.SinhVien)
                .Include(h => h.GiangVien)
                .Include(h => h.DeTai)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (huongDan == null)
            {
                return NotFound();
            }

            ViewBag.SinhVienList = new SelectList(_context.SinhVien, "MaSV", "HoTenSV", huongDan.SinhVien?.MaSV);
            ViewBag.DeTaiList = new SelectList(_context.DeTai, "MaDT", "TenDT", huongDan.DeTai?.MaDT);
            ViewBag.GiangVienList = new SelectList(_context.GiangVien, "MaGV", "HoTenGV", huongDan.GiangVien?.MaGV);

            return View(huongDan);
        }



        // POST: HuongDans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id,KetQua,MaSV,MaDT,MaGV")] HuongDan huongDan)
        {
            if (id != huongDan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    huongDan.SinhVien = await _context.SinhVien.FindAsync(huongDan.MaSV);
                    huongDan.GiangVien = await _context.GiangVien.FindAsync(huongDan.MaGV);
                    huongDan.DeTai = await _context.DeTai.FindAsync(huongDan.MaDT);

                    _context.Update(huongDan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuongDanExists(huongDan.Id))
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

            ViewBag.SinhVienList = new SelectList(_context.SinhVien, "MaSV", "HoTenSV", huongDan.MaSV);
            ViewBag.DeTaiList = new SelectList(_context.DeTai, "MaDT", "TenDT", huongDan.MaDT);
            ViewBag.GiangVienList = new SelectList(_context.GiangVien, "MaGV", "HoTenGV", huongDan.MaGV);

            return View(huongDan);
        }

        // GET: HuongDans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HuongDan == null)
            {
                return NotFound();
            }

            var huongDan = await _context.HuongDan
                .Include(h => h.SinhVien)
                .Include(h => h.GiangVien)
                .Include(h => h.DeTai)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (huongDan == null)
            {
                return NotFound();
            }

            return View(huongDan);
        }


        // POST: HuongDans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HuongDan == null)
            {
                return Problem("Entity set 'ThucTap1Context.HuongDan' is null.");
            }

            var huongDan = await _context.HuongDan
                .Include(h => h.SinhVien)
                .Include(h => h.GiangVien)
                .Include(h => h.DeTai)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (huongDan == null)
            {
                return NotFound();
            }

            _context.HuongDan.Remove(huongDan);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool HuongDanExists(int id)
        {
            return (_context.HuongDan?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
