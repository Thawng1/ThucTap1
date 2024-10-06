using Microsoft.EntityFrameworkCore;
using ThucTap1.Data;
using ThucTap1.Interface;

namespace ThucTap1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add DbContext with connection string
            var connectionString = builder.Configuration.GetConnectionString("ThucTap1Context")
                ?? throw new InvalidOperationException("Connection string 'ThucTap1Context' not found.");
            builder.Services.AddDbContext<ThucTap1Context>(options =>
                options.UseSqlServer(connectionString));

            // Add Quanlythuctap service
            builder.Services.AddScoped<IQuanlythuctap, Quanlythuctap>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
