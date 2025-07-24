using BooksShop.DTO;
using BooksShop.Interfaces.Admission;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/AdmissionController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionService _admissionService;

        public AdmissionController(IAdmissionService admissionService)
        {
            _admissionService = admissionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdmissionDto>>> GetAllAdmission()
        {
            var admission = await _admissionService.GetAllAdmissionAsync();
            return Ok(admission);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdmissionDto>> GetAdmission(int id)
        {
            var admission = await _admissionService.GetAdmissionByIdAsync(id);
            if (admission == null) return NotFound();
            return Ok(admission);
        }

        [HttpPost]
        public async Task<ActionResult> AddAdmission([FromBody] CreateAdmissionDto admissionDto)
        {
            await _admissionService.AddAdmissionAsync(admissionDto);
            return CreatedAtAction(nameof(GetAdmission), admissionDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdmission(int id, [FromBody] CreateAdmissionDto admissionDto)
        {
            await _admissionService.UpdateAdmissionAsync(id, admissionDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmission(int id)
        {
            await _admissionService.DeleteAdmissionAsync(id);
            return NoContent();
        }
    }
}