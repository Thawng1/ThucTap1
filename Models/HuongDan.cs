using System.ComponentModel.DataAnnotations;

namespace ThucTap1.Models
{
    public class HuongDan
    {
        [Key]
        public int Id { get; set; }
        public int MaSV { get; set; }
        public int MaGV { get; set; }
        public string MaDT { get; set; }
        public virtual GiangVien? GiangVien { get; set; }
        public virtual SinhVien? SinhVien { get; set; }
        public virtual DeTai? DeTai { get; set; }

        public decimal? KetQua {  get; set; }
    }
}
