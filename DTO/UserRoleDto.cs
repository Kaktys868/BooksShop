using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class UserRoleDto
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string RoleName { get; set; }
    }
    public class CreateUserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
