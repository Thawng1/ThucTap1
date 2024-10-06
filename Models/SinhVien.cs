using System.ComponentModel.DataAnnotations;

namespace ThucTap1.Models
{
    public class SinhVien
    {
        [Key]
        [Required]
        public int MaSV { get; set; }
        public string HoTenSV { get; set; }
        public string MaKhoa { get; set; }
        public int? NamSinh { get; set; }
        public string QueQuan { get; set; }
        public virtual Khoa? Khoa { get; set; }
        public virtual ICollection<HuongDan> HuongDan { get; set; }
    }
}
