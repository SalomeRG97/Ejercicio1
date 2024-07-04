using Ejercicio1.DTO;

namespace Ejercicio1.Interfaces
{
    public interface IPatronLuzService
    {
        Task Add(CreatePatronLuzDTO dto);
        Task Delete(PatronLuzDTO dto);
        Task<List<PatronLuzDTO>> GetAll();
        Task Update(PatronLuzDTO dto);
    }
}