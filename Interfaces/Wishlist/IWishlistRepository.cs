namespace BooksShop.Interfaces.Wishlist
{
    public interface IWishlistRepository
    {
        Task<Models.Wishlist> GetByIdAsync(int id);
        Task<IEnumerable<Models.Wishlist>> GetAllAsync();
        Task AddAsync(Models.Wishlist wishlist);
        Task UpdateAsync(Models.Wishlist wishlist);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}