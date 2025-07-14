using System.Numerics;

namespace BooksShop.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserFIO { get; set; }
        public string UserPhoneNumber { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } 
            = new List<UserRole>();
        public ICollection<WishlistUser> WishlistUsers { get; set; }
            = new List<WishlistUser>();
        public ICollection<Review> Reviews { get; set; }
            = new List<Review>();
        public ICollection<Cart> Carts { get; set; }
            = new List<Cart>();
        public ICollection<Order> Orders { get; set; }
            = new List<Order>();
    }
}
