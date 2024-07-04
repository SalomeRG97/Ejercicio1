
using System.Threading.Tasks;

namespace Ejercicio1.Api.ServiceCall
{
    public interface IApiLucesController
    {
        Task<List<PatronLuces>> Get();
        Task<ResultadoValidacion> Validar(MedicionLuces medicion, int patronSeleccionado);
        Task<MiViewModel> GetByCode(int id);
    }
}