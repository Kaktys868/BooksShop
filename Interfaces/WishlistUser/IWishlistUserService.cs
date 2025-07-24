using BooksShop.DTO;

namespace BooksShop.Interfaces.WishlistUser
{
    public interface IWishlistUserService
    {
        Task<WishlistUserDto> GetWishlistUserByIdAsync(int id);
        Task<IEnumerable<WishlistUserDto>> GetAllWishlistUserAsync();
        Task AddWishlistUserAsync(CreateWishlistUserDto wishlistUserDto);
        Task UpdateWishlistUserAsync(int id, CreateWishlistUserDto wishlistUserDto);
        Task DeleteWishlistUserAsync(int id);
    }
}
