namespace BooksShop.Interfaces.WishlistBook
{
    public interface IWishlistBookRepository
    {
        Task<Models.WishlistBook> GetByIdAsync(int id);
        Task<IEnumerable<Models.WishlistBook>> GetAllAsync();
        Task AddAsync(Models.WishlistBook wishlistBook);
        Task UpdateAsync(Models.WishlistBook wishlistBook);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}