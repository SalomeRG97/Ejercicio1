using Configuraciones.Automapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Ejercicios
{
    public class Ejercicio_AutomapperIoC
    {
        public static void ConfigureServie(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Ejercicio1_MappingProfile));
        }
    }
}
