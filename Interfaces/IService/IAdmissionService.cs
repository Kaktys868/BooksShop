using BooksShop.DTO;
using BooksShop.Models;

namespace BooksShop.Interfaces.IService
{
    /// <summary>
    /// Интерфейс сервиса для работы с поступлениями книг
    /// </summary>
    public interface IAdmissionService
    {
        /// <summary>
        /// Получает информацию о поступлении по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>DTO поступления</returns>
        Task<AdmissionDto> GetAdmissionByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает список всех поступлений
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Коллекция DTO поступлений</returns>
        Task<IEnumerable<AdmissionDto>> GetAllAdmissionAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новое поступление
        /// </summary>
        /// <param name="admissionDto">DTO с данными нового поступления</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task AddAdmissionAsync(CreateAdmissionDto admissionDto, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет данные поступления
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="admissionDto">DTO с обновленными данными поступления</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task UpdateAdmissionAsync(int id, CreateAdmissionDto admissionDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет поступление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task DeleteAdmissionAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет все записи о поступлениях
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        Task DeleteAdmissionAllAsync(CancellationToken cancellationToken);
    }
}
