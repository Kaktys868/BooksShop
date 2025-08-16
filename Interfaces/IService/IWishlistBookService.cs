using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    public interface IWishlistBookService
    {
        Task<WishlistBookDto> GetWishlistBookByIdAsync(int id);
        Task<IEnumerable<WishlistBookDto>> GetAllWishlistBookAsync();
        Task AddWishlistBookAsync(CreateWishlistBookDto wishlistBookDto);
        Task UpdateWishlistBookAsync(int id, CreateWishlistBookDto wishlistBookDto);
        Task DeleteWishlistBookAsync(int id);
    }
}
