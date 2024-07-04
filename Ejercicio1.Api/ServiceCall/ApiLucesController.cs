
namespace Ejercicio1.Api.ServiceCall
{
    public class ApiLucesController : HttpBase, IApiLucesController
    {
        public ApiLucesController(HttpClient httpClient) : base(httpClient)
        {
        }
        public async Task<List<PatronLuces>> Get() => await Get<List<PatronLuces>>("Luces/Get");
        public async Task<MiViewModel> GetByCode(int id) => await Get<MiViewModel>($"Luces/GetByCode/{id}");
        public async Task<ResultadoValidacion> Validar(MedicionLuces medicion, int patronSeleccionado)
        {
            try
            {
                var response = await Post<ResultadoValidacion, MedicionLuces>("Luces/validar", medicion, patronSeleccionado);

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
