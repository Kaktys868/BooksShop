using BooksShop.Models;

namespace BooksShop.Interfaces.IRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы с авторами
    /// </summary>
    public interface IAuthorRepository
    {
        /// <summary>
        /// Получает автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Автор</returns>
        Task<Author> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает всех авторов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция авторов</returns>
        Task<IEnumerable<Author>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового автора
        /// </summary>
        /// <param name="author">Данные автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task AddAsync(Author author, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет данные автора
        /// </summary>
        /// <param name="author">Обновленные данные автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task UpdateAsync(Author author, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task DeleteAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет всех авторов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task DeleteAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Проверяет существование автора
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат проверки существования</returns>
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    }
}