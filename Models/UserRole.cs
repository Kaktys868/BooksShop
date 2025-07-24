using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string RoleName { get; set; }


        public User User { get; set; }
        public Role Role { get; set; }
    }
}
