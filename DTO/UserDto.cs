namespace BooksShop.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserFIO { get; set; }
        public string UserPhoneNumber { get; set; }
    }
    public class CreateUserDto
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserFIO { get; set; }
        public string UserPhoneNumber { get; set; }
    }
}
