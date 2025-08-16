namespace BooksShop.Interfaces.IRepository
{
    public interface IWishlistUserRepository
    {
        Task<Models.WishlistUser> GetByIdAsync(int id);
        Task<IEnumerable<Models.WishlistUser>> GetAllAsync();
        Task AddAsync(Models.WishlistUser wishlistUser);
        Task UpdateAsync(Models.WishlistUser wishlistUser);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}