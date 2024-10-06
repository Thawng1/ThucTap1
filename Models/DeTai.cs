using System.ComponentModel.DataAnnotations;

namespace ThucTap1.Models
{
    public class DeTai
    {
        [Key]
        public string MaDT { get; set; }
        public string TenDT { get; set; }
        public int KinhPhi { get; set; }
        public string NoiThucTap { get; set; }
        public virtual ICollection<HuongDan> HuongDan { get; set; }
    }
}
