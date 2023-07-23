namespace MangoShop.Services.CouponApi.Models.Dto;

public class CouponDto
{
    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 优惠代码
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 优惠金额
    /// </summary>
    public double DiscountAmount { get; set; }

    /// <summary>
    /// 最低使用金额
    /// </summary>
    public int MinAmount { get; set; }
}