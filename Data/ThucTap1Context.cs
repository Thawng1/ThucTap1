using Azure;
using Microsoft.EntityFrameworkCore;
using ThucTap1.Models;

namespace ThucTap1.Data
{
    public class ThucTap1Context : DbContext
    {
        public ThucTap1Context(DbContextOptions<ThucTap1Context> options)
            : base(options)
        {
        }

        public DbSet<Khoa> Khoa { get; set; }
        public DbSet<GiangVien> GiangVien { get; set; }
        public DbSet<SinhVien> SinhVien { get; set; }
        public DbSet<DeTai> DeTai { get; set; }
        public DbSet<HuongDan> HuongDan { get; set; }
    }
}