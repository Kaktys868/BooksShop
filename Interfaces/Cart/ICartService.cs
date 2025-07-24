using BooksShop.DTO;

namespace BooksShop.Interfaces.Cart
{
    public interface ICartService
    {
        Task<CartDto> GetCartByIdAsync(int id);
        Task<IEnumerable<CartDto>> GetAllCartAsync();
        Task AddCartAsync(CreateCartDto cartDto);
        Task UpdateCartAsync(int id, CreateCartDto cartDto);
        Task DeleteCartAsync(int id);
    }
}
