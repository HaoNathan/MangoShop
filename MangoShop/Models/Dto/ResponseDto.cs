namespace MangoShop.Services.CouponApi.Models.Dto
{
    public class ResponseDto
    {
        /// <summary>
        /// 成功标识
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// 数据
        /// </summary>
        public object? Data { get; set; }
    }
}
