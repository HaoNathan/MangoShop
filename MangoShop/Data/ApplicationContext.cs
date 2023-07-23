using MangoShop.Services.CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MangoShop.Services.CouponApi.Data;

public class AppDbContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 配置
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        modelBuilder.Entity<Coupon>().HasData(
            new Coupon
            {
                Id = Guid.NewGuid().ToString("N"),
                Code = "AB4FE",
                DiscountAmount = 10,
                MinAmount = 100,
                CreationTime = DateTime.Now
            }, new Coupon
            {
                Id = Guid.NewGuid().ToString("N"),
                Code = "Fk778",
                DiscountAmount = 6.6,
                MinAmount = 88,
                CreationTime = DateTime.Now
            });
    }
}