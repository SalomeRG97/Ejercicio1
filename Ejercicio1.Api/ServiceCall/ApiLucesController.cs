
namespace Ejercicio1.Api.ServiceCall
{
    public class ApiLucesController : HttpBase, IApiLucesController
    {
        public ApiLucesController(HttpClient httpClient) : base(httpClient)
        {
        }
        public async Task<ResultadoValidacion> Validar(PatronLuces patron)
        {
            try
            {
                var response = await Post<ResultadoValidacion, PatronLuces>("Luces/validar", patron);

                if (response != null)
                {
                    return response;
                }
                else
                {
                    throw new Exception("La validación no devolvió ningún resultado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la validación: {ex.Message}");
            }
        }

    }
}
