namespace BooksShop.Interfaces.IRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы с поступлениями книг
    /// </summary>
    public interface IAdmissionRepository
    {
        /// <summary>
        /// Получает поступление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Модель поступления</returns>
        Task<Models.Admission> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает все поступления
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Коллекция поступлений</returns>
        Task<IEnumerable<Models.Admission>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новое поступление
        /// </summary>
        /// <param name="admission">Данные поступления</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task AddAsync(Models.Admission admission, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет данные поступления
        /// </summary>
        /// <param name="admission">Обновленные данные</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task UpdateAsync(Models.Admission admission, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет поступление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task DeleteAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверяет существование поступления
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Результат проверки</returns>
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет все поступления
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task DeleteAllAsync(CancellationToken cancellationToken);
    }
}