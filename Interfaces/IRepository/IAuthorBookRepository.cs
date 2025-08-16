namespace BooksShop.Interfaces.IRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы со связями авторов и книг
    /// </summary>
    public interface IAuthorBookRepository
    {
        /// <summary>
        /// Получает связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Связь автора и книги</returns>
        Task<Models.AuthorBook> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает все связи авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция связей авторов и книг</returns>
        Task<IEnumerable<Models.AuthorBook>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новую связь автора и книги
        /// </summary>
        /// <param name="authorBook">Данные связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task AddAsync(Models.AuthorBook authorBook, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующую связь автора и книги
        /// </summary>
        /// <param name="authorBook">Обновленные данные связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task UpdateAsync(Models.AuthorBook authorBook, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task DeleteAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет все связи авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task DeleteAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Проверяет существование связи автора и книги
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат проверки существования</returns>
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    }
}
