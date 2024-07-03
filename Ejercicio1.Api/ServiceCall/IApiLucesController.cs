
namespace Ejercicio1.Api.ServiceCall
{
    public interface IApiLucesController
    {
        Task<ResultadoValidacion> Validar(PatronLuces patron);
    }
}