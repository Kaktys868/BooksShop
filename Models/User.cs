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
        public ICollection<WishlistUser> WishlistUsers { get; set; }
        public User()
        {
            UserRoles = new List<UserRole>();
            WishlistUsers = new List<WishlistUser>();
        }
    }
}
