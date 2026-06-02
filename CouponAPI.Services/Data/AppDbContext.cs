using Microsoft.EntityFrameworkCore;

namespace CouponAPI.Services.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Tables
        public DbSet<Models.Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Models.Coupon>().HasData(
                new Models.Coupon { CouponId = 1, CouponCode = "SAVE10", DiscountAmount = 10.0, MinAmount = "50" },
                new Models.Coupon { CouponId = 2, CouponCode = "SAVE20", DiscountAmount = 20.0, MinAmount = "100"},
                new Models.Coupon { CouponId = 3, CouponCode = "SAVE30", DiscountAmount = 30.0, MinAmount = "150" }
            );
        }
    }
}
