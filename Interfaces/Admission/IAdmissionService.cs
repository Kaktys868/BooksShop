using BooksShop.DTO;

namespace BooksShop.Interfaces.Admission
{
    public interface IAdmissionService
    {
        Task<AdmissionDto> GetAdmissionByIdAsync(int id);
        Task<IEnumerable<AdmissionDto>> GetAllAdmissionAsync();
        Task AddAdmissionAsync(CreateAdmissionDto admissionDto);
        Task UpdateAdmissionAsync(int id, CreateAdmissionDto admissionDto);
        Task DeleteAdmissionAsync(int id);
    }
}
