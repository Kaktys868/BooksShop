using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.Admission;
using BooksShop.Models;

namespace BooksShop.Services
{
    public class AdmissionService : IAdmissionService
    {
        private readonly IAdmissionRepository _AdmissionRepository;
        private readonly IMapper _mapper;

        public AdmissionService(IAdmissionRepository AdmissionRepository, IMapper mapper)
        {
            _AdmissionRepository = AdmissionRepository;
            _mapper = mapper;
        }

        public async Task<AdmissionDto> GetAdmissionByIdAsync(int id)
        {
            var Admission = await _AdmissionRepository.GetByIdAsync(id);
            return _mapper.Map<AdmissionDto>(Admission);
        }

        public async Task<IEnumerable<AdmissionDto>> GetAllAdmissionAsync()
        {
            var Admissions = await _AdmissionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AdmissionDto>>(Admissions);
        }

        public async Task AddAdmissionAsync(CreateAdmissionDto AdmissionDto)
        {
            var Admission = _mapper.Map<Admission>(AdmissionDto);
            await _AdmissionRepository.AddAsync(Admission);
        }

        public async Task UpdateAdmissionAsync(int id, CreateAdmissionDto AdmissionDto)
        {

            var Admission = await _AdmissionRepository.GetByIdAsync(id);
            _mapper.Map(AdmissionDto, Admission);
            await _AdmissionRepository.UpdateAsync(Admission);
        }

        public async Task DeleteAdmissionAsync(int id)
        {
            await _AdmissionRepository.DeleteAsync(id);
        }
    }
}