using BooksShop.DTO;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    /// <summary>
    /// Контроллер для работы с поступлениями книг
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionService _admissionService;

        /// <summary>
        /// Конструктор контроллера поступлений
        /// </summary>
        /// <param name="admissionService">Сервис для работы с поступлениями</param>
        public AdmissionController(IAdmissionService admissionService)
        {
            _admissionService = admissionService;
        }

        /// <summary>
        /// Получает список всех поступлений
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список поступлений</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdmissionDto>>> GetAllAdmission(CancellationToken cancellationToken)
        {
            var admission = await _admissionService.GetAllAdmissionAsync(cancellationToken);
            return Ok(admission);
        }

        /// <summary>
        /// Получает поступление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Поступление с указанным идентификатором</returns>
        /// <response code="200">Поступление найдено</response>
        /// <response code="404">Поступление не найдено</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<AdmissionDto>> GetAdmission(int id, CancellationToken cancellationToken)
        {
            var admission = await _admissionService.GetAdmissionByIdAsync(id, cancellationToken);
            if (admission == null) return NotFound();
            return Ok(admission);
        }

        /// <summary>
        /// Добавляет новое поступление
        /// </summary>
        /// <param name="admissionDto">Данные нового поступления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Созданное поступление</returns>
        /// <response code="201">Поступление успешно создано</response>
        [HttpPost]
        public async Task<ActionResult> AddAdmission(
            [FromBody] CreateAdmissionDto admissionDto,
            CancellationToken cancellationToken)
        {
            await _admissionService.AddAdmissionAsync(admissionDto, cancellationToken);
            return CreatedAtAction(nameof(GetAdmission), admissionDto);
        }

        /// <summary>
        /// Обновляет существующее поступление
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="admissionDto">Обновленные данные поступления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Поступление успешно обновлено</response>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdmission(
            int id,
            [FromBody] CreateAdmissionDto admissionDto,
            CancellationToken cancellationToken)
        {
            await _admissionService.UpdateAdmissionAsync(id, admissionDto, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Удаляет все поступления
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Все поступления успешно удалены</response>
        [HttpDelete]
        public async Task<ActionResult> DeleteAdmissionAll(CancellationToken cancellationToken)
        {
            await _admissionService.DeleteAdmissionAllAsync(cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Удаляет поступление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поступления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Поступление успешно удалено</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmission(int id, CancellationToken cancellationToken)
        {
            await _admissionService.DeleteAdmissionAsync(id, cancellationToken);
            return NoContent();
        }
    }
}