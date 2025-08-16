using BooksShop.Classes.Common;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    /// <summary>
    /// Репозиторий для работы со связями авторов и книг
    /// </summary>
    public class AuthorBookRepository : IAuthorBookRepository
    {
        private readonly DbConnect _context;

        /// <summary>
        /// Конструктор репозитория связей авторов и книг
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public AuthorBookRepository(DbConnect context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Связь автора и книги</returns>
        public async Task<AuthorBook> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.AuthorBook
                .Select(ab => new AuthorBook
                {
                    AuthorBookId = ab.AuthorBookId,
                    AuthorId = ab.AuthorId,
                    BookId = ab.BookId,
                    BookName = ab.Book.BookName,
                    AuthorName = ab.Author.AuthorFIO
                })
                .FirstOrDefaultAsync(ab => ab.AuthorBookId == id, cancellationToken);
        }

        /// <summary>
        /// Получает все связи авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех связей авторов и книг</returns>
        public async Task<IEnumerable<AuthorBook>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.AuthorBook
                .Select(ab => new AuthorBook
                {
                    AuthorBookId = ab.AuthorBookId,
                    AuthorId = ab.AuthorId,
                    BookId = ab.BookId,
                    BookName = ab.Book.BookName,
                    AuthorName = ab.Author.AuthorFIO
                })
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Добавляет новую связь автора и книги
        /// </summary>
        /// <param name="authorBook">Данные связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task AddAsync(AuthorBook authorBook, CancellationToken cancellationToken)
        {
            await _context.AuthorBook.AddAsync(authorBook, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновляет существующую связь автора и книги
        /// </summary>
        /// <param name="authorBook">Обновленные данные связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task UpdateAsync(AuthorBook authorBook, CancellationToken cancellationToken)
        {
            _context.AuthorBook.Update(authorBook);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удаляет связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var authorBook = await _context.AuthorBook
                .FirstOrDefaultAsync(ab => ab.AuthorBookId == id, cancellationToken);

            if (authorBook != null)
            {
                _context.AuthorBook.Remove(authorBook);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Удаляет все связи авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAllAsync(CancellationToken cancellationToken)
        {
            await _context.AuthorBook.ExecuteDeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Проверяет существование связи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>True, если связь существует, иначе False</returns>
        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.AuthorBook
                .AnyAsync(ab => ab.AuthorBookId == id, cancellationToken);
        }
    }
}