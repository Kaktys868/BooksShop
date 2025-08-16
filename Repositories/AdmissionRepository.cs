using BooksShop.Classes.Common;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    /// <summary>
    /// Репозиторий для работы с поступлениями книг
    /// </summary>
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly DbConnect _context;

        /// <summary>
        /// Конструктор репозитория поступлений
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public AdmissionRepository(DbConnect context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает поступление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Поступление с указанным идентификатором</returns>
        public async Task<Admission> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Admission
                .Select(a => new Admission
                {
                    AdmissionId = a.AdmissionId,
                    AdmissionDate = a.AdmissionDate,
                    AdmissionQuantity = a.AdmissionQuantity,
                    AdmissionWarehouseId = a.AdmissionWarehouseId,
                    AdmissionBookId = a.AdmissionBookId,
                    WarehouseName = a.Warehouse.WarehouseName,
                    BookName = a.Book.BookName
                })
                .FirstOrDefaultAsync(b => b.AdmissionId == id, cancellationToken);

        }

        /// <summary>
        /// Получает все поступления
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех поступлений</returns>
        public async Task<IEnumerable<Admission>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Admission
                .Select(a => new Admission
                {
                    AdmissionId = a.AdmissionId,
                    AdmissionDate = a.AdmissionDate,
                    AdmissionQuantity = a.AdmissionQuantity,
                    AdmissionWarehouseId = a.AdmissionWarehouseId,
                    AdmissionBookId = a.AdmissionBookId,
                    WarehouseName = a.Warehouse.WarehouseName,
                    BookName = a.Book.BookName
                })
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Добавляет новое поступление
        /// </summary>
        /// <param name="admission">Данные поступления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task AddAsync(Admission admission, CancellationToken cancellationToken)
        {
            await _context.Admission.AddAsync(admission, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновляет существующее поступление
        /// </summary>
        /// <param name="admission">Данные поступления для обновления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task UpdateAsync(Admission admission, CancellationToken cancellationToken)
        {
            _context.Admission.Update(admission);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удаляет поступление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var admission = await _context.Admission
                .FirstOrDefaultAsync(a => a.AdmissionId == id, cancellationToken);

            if (admission != null)
            {
                _context.Admission.Remove(admission);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Удаляет все поступления
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAllAsync(CancellationToken cancellationToken)
        {
            await _context.Admission.ExecuteDeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Проверяет существование поступления по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>True, если поступление существует, иначе False</returns>
        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Admission
                .AnyAsync(b => b.AdmissionId == id, cancellationToken);
        }
    }
}