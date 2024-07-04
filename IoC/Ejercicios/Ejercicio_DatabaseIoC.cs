using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ejercicio1.Entidades;

namespace IoC.Ejercicios
{
    public class Ejercicio_DatabaseIoC
    {
        public static void ConfigureSQLServerService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<EjerciciosContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
