namespace BooksShop.DTO
{
    public class WishlistDto
    {
        public int WishlistId { get; set; }
        public DateOnly WishlistAddDate { get; set; }
        public string WishlistName { get; set; }
    }
    public class CreateWishlistDto
    {
        public DateOnly WishlistAddDate { get; set; }
    }
}