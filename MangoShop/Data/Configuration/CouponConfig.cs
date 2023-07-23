using MangoShop.Services.CouponApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MangoShop.Services.CouponApi.Data.Configuration;

public class CouponConfig : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(32).IsUnicode(false);
        builder.Property(x => x.Code).IsRequired().HasMaxLength(10).IsUnicode(false).HasComment("优惠券代码");
        builder.Property(x => x.DiscountAmount).IsRequired().HasComment("优惠金额");
        builder.Property(x => x.CreationTime).HasColumnType("datetime");
        builder.Property(x => x.UpdateTime).HasColumnType("datetime");
    }
}