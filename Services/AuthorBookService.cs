using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;
using BooksShop.Models;

namespace BooksShop.Services
{
    /// <summary>
    /// Сервис для работы со связями авторов и книг
    /// </summary>
    public class AuthorBookService : IAuthorBookService
    {
        private readonly IAuthorBookRepository _AuthorBookRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор сервиса связей авторов и книг
        /// </summary>
        /// <param name="AuthorBookRepository">Репозиторий для работы со связями авторов и книг</param>
        /// <param name="mapper">Автомаппер для преобразования DTO</param>
        public AuthorBookService(IAuthorBookRepository AuthorBookRepository, IMapper mapper)
        {
            _AuthorBookRepository = AuthorBookRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>DTO связи автора и книги</returns>
        public async Task<AuthorBookDto> GetAuthorBookByIdAsync(int id, CancellationToken cancellationToken)
        {
            var AuthorBook = await _AuthorBookRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<AuthorBookDto>(AuthorBook);
        }

        /// <summary>
        /// Получает все связи авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция DTO связей авторов и книг</returns>
        public async Task<IEnumerable<AuthorBookDto>> GetAllAuthorBookAsync(CancellationToken cancellationToken)
        {
            var AuthorBooks = await _AuthorBookRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<AuthorBookDto>>(AuthorBooks);
        }

        /// <summary>
        /// Добавляет новую связь автора и книги
        /// </summary>
        /// <param name="AuthorBookDto">DTO для создания связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task AddAuthorBookAsync(CreateAuthorBookDto AuthorBookDto, CancellationToken cancellationToken)
        {
            var AuthorBook = _mapper.Map<AuthorBook>(AuthorBookDto);
            await _AuthorBookRepository.AddAsync(AuthorBook, cancellationToken);
        }

        /// <summary>
        /// Обновляет существующую связь автора и книги
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="AuthorBookDto">DTO с обновленными данными</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task UpdateAuthorBookAsync(int id, CreateAuthorBookDto AuthorBookDto, CancellationToken cancellationToken)
        {
            var AuthorBook = await _AuthorBookRepository.GetByIdAsync(id, cancellationToken);
            _mapper.Map(AuthorBookDto, AuthorBook);
            await _AuthorBookRepository.UpdateAsync(AuthorBook, cancellationToken);
        }

        /// <summary>
        /// Удаляет связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAuthorBookAsync(int id, CancellationToken cancellationToken)
        {
            await _AuthorBookRepository.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Удаляет все связи авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAuthorBookAllAsync(CancellationToken cancellationToken)
        {
            await _AuthorBookRepository.DeleteAllAsync(cancellationToken);
        }
    }
}