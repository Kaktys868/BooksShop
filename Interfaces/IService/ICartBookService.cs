using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    public interface ICartBookService
    {
        Task<CartBookDto> GetCartBookByIdAsync(int id);
        Task<IEnumerable<CartBookDto>> GetAllCartBookAsync();
        Task AddCartBookAsync(CreateCartBookDto cartBookDto);
        Task UpdateCartBookAsync(int id, CreateCartBookDto cartBookDto);
        Task DeleteCartBookAsync(int id);
    }
}
