namespace MangoShop.Services.CouponApi.Models;

public class Coupon
{
    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 优惠代码
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// 优惠金额
    /// </summary>
    public double DiscountAmount { get; set; }

    /// <summary>
    /// 最低使用金额
    /// </summary>
    public int MinAmount { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}