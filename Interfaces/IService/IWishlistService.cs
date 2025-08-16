using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    public interface IWishlistService
    {
        Task<WishlistDto> GetWishlistByIdAsync(int id);
        Task<IEnumerable<WishlistDto>> GetAllWishlistAsync();
        Task AddWishlistAsync(CreateWishlistDto wishlistDto);
        Task UpdateWishlistAsync(int id, CreateWishlistDto wishlistDto);
        Task DeleteWishlistAsync(int id);
    }
}
