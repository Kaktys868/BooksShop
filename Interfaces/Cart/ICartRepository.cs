namespace BooksShop.Interfaces.Cart
{
    public interface ICartRepository
    {
        Task<Models.Cart> GetByIdAsync(int id);
        Task<IEnumerable<Models.Cart>> GetAllAsync();
        Task AddAsync(Models.Cart cart);
        Task UpdateAsync(Models.Cart cart);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
