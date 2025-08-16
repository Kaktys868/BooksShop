using BooksShop.Classes.Common;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    /// <summary>
    /// Репозиторий для работы с авторами
    /// </summary>
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DbConnect _context;

        /// <summary>
        /// Конструктор репозитория авторов
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public AuthorRepository(DbConnect context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Автор с указанным идентификатором</returns>
        public async Task<Author> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Author
                .Select(b => new Author
                {
                    AuthorId = b.AuthorId,
                    AuthorFIO = b.AuthorFIO,
                    AuthorDateOfBorn = b.AuthorDateOfBorn,
                    AuthorDateOfDeath = b.AuthorDateOfDeath
                })
                .FirstOrDefaultAsync(b => b.AuthorId == id, cancellationToken);
        }

        /// <summary>
        /// Получает всех авторов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех авторов</returns>
        public async Task<IEnumerable<Author>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Author
                .Select(b => new Author
                {
                    AuthorId = b.AuthorId,
                    AuthorFIO = b.AuthorFIO,
                    AuthorDateOfBorn = b.AuthorDateOfBorn,
                    AuthorDateOfDeath = b.AuthorDateOfDeath
                })
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Добавляет нового автора
        /// </summary>
        /// <param name="author">Данные автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task AddAsync(Author author, CancellationToken cancellationToken)
        {
            await _context.Author.AddAsync(author, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновляет данные автора
        /// </summary>
        /// <param name="author">Обновленные данные автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task UpdateAsync(Author author, CancellationToken cancellationToken)
        {
            _context.Author.Update(author);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удаляет автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var author = await _context.Author
                .FirstOrDefaultAsync(a => a.AuthorId == id, cancellationToken);

            if (author != null)
            {
                _context.Author.Remove(author);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Удаляет всех авторов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAllAsync(CancellationToken cancellationToken)
        {
            await _context.Author.ExecuteDeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Проверяет существование автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>True, если автор существует, иначе False</returns>
        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Author
                .AnyAsync(a => a.AuthorId == id, cancellationToken);
        }
    }
}