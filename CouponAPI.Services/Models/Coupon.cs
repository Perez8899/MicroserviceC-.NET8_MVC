using System.ComponentModel.DataAnnotations;

namespace CouponAPI.Services.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public string MinAmount { get; set; }
    
    }
}
