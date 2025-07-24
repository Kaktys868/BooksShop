namespace BooksShop.DTO
{
    public class WishlistDto
    {
        public int WishlistId { get; set; }
        public DateOnly WishlistAddDate { get; set; }
    }
    public class CreateWishlistDto
    {
        public int WishlistId { get; set; }
    }
}
