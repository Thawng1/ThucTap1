using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThucTap1.Data;
using ThucTap1.Interface;
using ThucTap1.Models;

namespace ThucTap1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ThucTap1Context _context;
        private readonly IQuanlythuctap _QuanLyThucTap;

        public HomeController(ThucTap1Context context, IQuanlythuctap quanLyThucTap)
        {
            _context = context;
            _QuanLyThucTap = quanLyThucTap;
        }

        // GET: HuongDans
        public async Task<IActionResult> Index(string? khoaFilter, string? searchTerm)
        {
            if (_context.HuongDan == null || _context.SinhVien == null)
            {
                return Problem("Data is null.");
            }

            var query = _context.SinhVien
                     .Include(s => s.Khoa) 
                     .Select(sv => new {
                         SinhVien = sv,
                         KetQua = _context.HuongDan
                                         .Where(hd => hd.SinhVien.MaSV == sv.MaSV)
                                         .Select(h => h.KetQua)
                                         .FirstOrDefault() 
                     }).AsQueryable();


            if (!string.IsNullOrEmpty(khoaFilter))
            {
                query = query.Where(h => h.SinhVien.MaKhoa == khoaFilter);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(h => h.SinhVien.MaSV.ToString().Contains(searchTerm) || h.SinhVien.HoTenSV.Contains(searchTerm));
            }

            var results = await query.ToListAsync();

            var totalSinhViens = _context.SinhVien.Count();
            var totalGiangViens = _context.GiangVien.Count();

            ViewBag.TotalSinhViens = totalSinhViens;
            ViewBag.TotalGiangViens = totalGiangViens;
            ViewBag.KhoaFilter = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", khoaFilter);

            return View(results);
        }

        public IActionResult ThongTinDiem(string masv)
        {
            if (string.IsNullOrEmpty(masv))
            {
                return NotFound();
            }

            var thongTinDiem = _QuanLyThucTap.GetThongtindiemSV(masv);

            if (thongTinDiem == null)
            {
                return NotFound();
            }

            return View(thongTinDiem);
        }

        public IActionResult DanhSachSinhVien(string makhoa, string magv)
        {
           if (string.IsNullOrEmpty(makhoa) || string.IsNullOrEmpty(magv))
             {
                return NotFound("MaKhoa or MaGV is null.");
            }

            var sinhVienList = _QuanLyThucTap.GetDanhsachSinhVien(makhoa, magv);

            if (sinhVienList == null || !sinhVienList.Any())
            {
                return NotFound("No students .");
            }

            return View(sinhVienList);
        }
    }

    }

