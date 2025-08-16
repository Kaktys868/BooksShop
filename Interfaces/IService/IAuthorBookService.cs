using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    /// <summary>
    /// Интерфейс сервиса для работы со связями авторов и книг
    /// </summary>
    public interface IAuthorBookService
    {
        /// <summary>
        /// Получает связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>DTO связи автора и книги</returns>
        Task<AuthorBookDto> GetAuthorBookByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает все связи авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Коллекция DTO связей авторов и книг</returns>
        Task<IEnumerable<AuthorBookDto>> GetAllAuthorBookAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Создает новую связь автора и книги
        /// </summary>
        /// <param name="authorBookDto">DTO для создания связи</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task AddAuthorBookAsync(CreateAuthorBookDto authorBookDto, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующую связь автора и книги
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="authorBookDto">DTO с обновленными данными</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task UpdateAuthorBookAsync(int id, CreateAuthorBookDto authorBookDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task DeleteAuthorBookAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет все связи авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task DeleteAuthorBookAllAsync(CancellationToken cancellationToken);
    }
}
