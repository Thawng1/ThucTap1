using ThucTap1.Models;

namespace ThucTap1.Interface
{
    public interface IQuanlythuctap
    {
        IEnumerable<SinhVien> GetDanhsachSinhVien(string makhoa, string magv);
        ThongTinDiemSV GetThongtindiemSV(string masv);
    }
    public class ThongTinDiemSV
    {
        public string Masv { get; set; }
        public decimal AverageScore { get; set; }
        public string Status { get; set; }
    }
}
