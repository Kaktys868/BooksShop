﻿namespace BooksShop.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserRole> RoleUsers { get; set; }
            = new List<UserRole>();
    }
}
