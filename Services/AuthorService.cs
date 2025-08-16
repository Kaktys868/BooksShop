using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;
using BooksShop.Models;
namespace BooksShop.Services
{
    /// <summary>
    /// Сервис для работы с авторами
    /// </summary>
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор сервиса авторов
        /// </summary>
        /// <param name="authorRepository">Репозиторий авторов</param>
        /// <param name="mapper">Автомаппер</param>
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>DTO автора</returns>
        public async Task<AuthorDto> GetAuthorByIdAsync(int id, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<AuthorDto>(author);
        }

        /// <summary>
        /// Получает всех авторов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция DTO авторов</returns>
        public async Task<IEnumerable<AuthorDto>> GetAllAuthorAsync(CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        /// <summary>
        /// Добавляет нового автора
        /// </summary>
        /// <param name="authorDto">DTO для создания автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task AddAuthorAsync(CreateAuthorDto authorDto, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.AddAsync(author, cancellationToken);
        }

        /// <summary>
        /// Обновляет данные автора
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="authorDto">DTO с обновленными данными</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task UpdateAuthorAsync(int id, CreateAuthorDto authorDto, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(id, cancellationToken);
            _mapper.Map(authorDto, author);
            await _authorRepository.UpdateAsync(author, cancellationToken);
        }

        /// <summary>
        /// Удаляет автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAuthorAsync(int id, CancellationToken cancellationToken)
        {
            await _authorRepository.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Удаляет всех авторов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        public async Task DeleteAllAuthorAsync(CancellationToken cancellationToken)
        {
            await _authorRepository.DeleteAllAsync(cancellationToken);
        }
    }
}