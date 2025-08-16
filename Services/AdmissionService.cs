using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Services
{
    public class AdmissionService : IAdmissionService
    {
        private readonly IAdmissionRepository _admissionRepository;
        private readonly IMapper _mapper;

        public AdmissionService(IAdmissionRepository admissionRepository, IMapper mapper)
        {
            _admissionRepository = admissionRepository;
            _mapper = mapper;
        }

        public async Task<AdmissionDto> GetAdmissionByIdAsync(int id, CancellationToken cancellationToken)
        {
            var admission = await _admissionRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<AdmissionDto>(admission);
        }

        public async Task<IEnumerable<AdmissionDto>> GetAllAdmissionAsync(CancellationToken cancellationToken)
        {
            var admissions = await _admissionRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<AdmissionDto>>(admissions);
        }

        public async Task AddAdmissionAsync(CreateAdmissionDto admissionDto, CancellationToken cancellationToken)
        {
            var admission = _mapper.Map<Admission>(admissionDto);
            await _admissionRepository.AddAsync(admission, cancellationToken);
        }

        public async Task UpdateAdmissionAsync(int id, CreateAdmissionDto admissionDto, CancellationToken cancellationToken)
        {
            var admission = await _admissionRepository.GetByIdAsync(id, cancellationToken);
            _mapper.Map(admissionDto, admission);
            await _admissionRepository.UpdateAsync(admission, cancellationToken);
        }

        public async Task DeleteAdmissionAsync(int id, CancellationToken cancellationToken)
        {
            await _admissionRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task DeleteAdmissionAllAsync(CancellationToken cancellationToken)
        {
            await _admissionRepository.DeleteAllAsync(cancellationToken);
        }
    }
}