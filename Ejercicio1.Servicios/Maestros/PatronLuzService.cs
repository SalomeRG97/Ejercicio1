using Ejercicio1.DTO;
using Ejercicio1.Interfaces;

namespace Ejercicio1.Servicios
{
    public class PatronLuzService : IPatronLuzService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatronLuzService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<PatronLuzDTO>> GetAll()
        {
            var data = await _unitOfWork.PatronLuzRepository.GetAllAsync<PatronLuzDTO>();
            return data;
        }
        public async Task Add(CreatePatronLuzDTO dto)
        {
            _unitOfWork.PatronLuzRepository.AddAsync(dto);
            await _unitOfWork.SaveChanges();
        }
        public async Task Update(PatronLuzDTO dto)
        {
            _unitOfWork.PatronLuzRepository.UpdateAsync(dto);
            await _unitOfWork.SaveChanges();
        }
        public async Task Delete(PatronLuzDTO dto)
        {
            _unitOfWork.PatronLuzRepository.DeleteAsync<PatronLuzDTO>(dto);
            await _unitOfWork.SaveChanges();
        }
    }
}
