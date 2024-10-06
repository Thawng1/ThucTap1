using Microsoft.EntityFrameworkCore;
using ThucTap1.Data;
using ThucTap1.Models;

namespace ThucTap1.Interface
{
    public class Quanlythuctap : IQuanlythuctap
    {
        private readonly ThucTap1Context _context;

        public Quanlythuctap(ThucTap1Context context)
        {
            _context = context;
        }

        public IEnumerable<SinhVien> GetDanhsachSinhVien(string makhoa, string magv)
        {

            var masvList = _context.HuongDan
                .Where(hd => hd.MaGV.ToString() == magv)
                .Select(hd => hd.MaSV)
                .Distinct()
                .ToList();


            return _context.SinhVien
                .Where(sv => sv.MaKhoa == makhoa && masvList.Contains(sv.MaSV))
                .ToList();
        }


        public ThongTinDiemSV GetThongtindiemSV(string masv)
        {
            var scores = _context.HuongDan
                .Where(hd => hd.MaSV.ToString() == masv)
                .ToList();

            var averageScore = scores.Average(s => s.KetQua);
            var status = scores.All(s => s.KetQua > 3) && averageScore >= 4 ? "Đạt" : "Chưa Đạt";

            return new ThongTinDiemSV
            {
                Masv = masv,
                AverageScore = (decimal)averageScore,
                Status = status
            };
        }

    }
}
