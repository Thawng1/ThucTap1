using System.ComponentModel.DataAnnotations;

namespace ThucTap1.Models
{
    public class Khoa
    {
        [Key]
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string DienThoai { get; set; }
        public virtual ICollection<GiangVien> GiangVien { get; set; }
        public virtual ICollection<SinhVien> SinhVien { get; set; }
    }
}
