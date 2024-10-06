using System.ComponentModel.DataAnnotations;

namespace ThucTap1.Models
{
    public class GiangVien
    {
        [Key]
        [Required]
        public int MaGV { get; set; }
        public string HoTenGV { get; set; }
        public decimal Luong { get; set; }
        public string MaKhoa { get; set; }
        public virtual Khoa? Khoa { get; set; }
        public virtual ICollection<HuongDan> HuongDan { get; set; }
    }
}
