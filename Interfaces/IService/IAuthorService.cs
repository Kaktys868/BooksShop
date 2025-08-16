using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    /// <summary>
    /// Интерфейс сервиса для работы с авторами
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Получает автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>DTO автора</returns>
        Task<AuthorDto> GetAuthorByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает список всех авторов
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Коллекция DTO авторов</returns>
        Task<IEnumerable<AuthorDto>> GetAllAuthorAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового автора
        /// </summary>
        /// <param name="authorDto">DTO с данными нового автора</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task AddAuthorAsync(CreateAuthorDto authorDto, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет данные автора
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="authorDto">DTO с обновленными данными</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task UpdateAuthorAsync(int id, CreateAuthorDto authorDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task DeleteAuthorAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет всех авторов
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task DeleteAllAuthorAsync(CancellationToken cancellationToken);
    }
}
