using BooksShop.DTO;
using BooksShop.Interfaces;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
namespace BooksShop.Controllers
{
    /// <summary>
    /// Контроллер для работы с связями авторов и книг
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v3")]
    public class AuthorBookController : ControllerBase
    {
        private readonly IAuthorBookService _AuthorBookService;

        /// <summary>
        /// Конструктор контроллера связей авторов и книг
        /// </summary>
        /// <param name="AuthorBookService">Сервис для работы со связями авторов и книг</param>
        public AuthorBookController(IAuthorBookService AuthorBookService)
        {
            _AuthorBookService = AuthorBookService;
        }

        /// <summary>
        /// Получает список всех связей авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список связей авторов и книг</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorBookDto>>> GetAllAuthorBook(CancellationToken cancellationToken)
        {
            var AuthorBook = await _AuthorBookService.GetAllAuthorBookAsync(cancellationToken);
            return Ok(AuthorBook);
        }

        /// <summary>
        /// Получает связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Связь автора и книги с указанным идентификатором</returns>
        /// <response code="200">Связь найдена</response>
        /// <response code="404">Связь не найдена</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthorBookDto>> GetAuthorBook(int id, CancellationToken cancellationToken)
        {
            var AuthorBook = await _AuthorBookService.GetAuthorBookByIdAsync(id, cancellationToken);
            if (AuthorBook == null) return NotFound();
            return Ok(AuthorBook);
        }

        /// <summary>
        /// Добавляет новую связь автора и книги
        /// </summary>
        /// <param name="AuthorBookDto">Данные новой связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Созданная связь</returns>
        /// <response code="201">Связь успешно создана</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddAuthorBook(
            [FromBody] CreateAuthorBookDto AuthorBookDto,
            CancellationToken cancellationToken)
        {
            await _AuthorBookService.AddAuthorBookAsync(AuthorBookDto, cancellationToken);
            return CreatedAtAction(nameof(GetAuthorBook), AuthorBookDto);
        }

        /// <summary>
        /// Обновляет существующую связь автора и книги
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="AuthorBookDto">Обновленные данные связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Связь успешно обновлена</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateAuthorBook(
            int id,
            [FromBody] CreateAuthorBookDto AuthorBookDto,
            CancellationToken cancellationToken)
        {
            await _AuthorBookService.UpdateAuthorBookAsync(id, AuthorBookDto, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Удаляет все связи авторов и книг
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Все связи успешно удалены</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAllAuthorBook(CancellationToken cancellationToken)
        {
            await _AuthorBookService.DeleteAuthorBookAllAsync(cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Удаляет связь автора и книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Связь успешно удалена</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAuthorBook(
            int id,
            CancellationToken cancellationToken)
        {
            await _AuthorBookService.DeleteAuthorBookAsync(id, cancellationToken);
            return NoContent();
        }
    }
}