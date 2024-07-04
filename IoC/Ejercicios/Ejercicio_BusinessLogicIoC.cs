

using Ejercicio1.Interfaces;
using Ejercicio1.Repositorio;
using Ejercicio1.Servicios;
using Ejercicio1.Repositorio.Repositorio.Maestros;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ejercicio1.Repositorio.Base;

namespace IoC.Ejercicios
{
    public class Ejercicio_BusinessLogicIoC
    {
        public static void RepositoryService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IMedicionLuzRepository, MedicionLuzRepository>();
            builder.Services.AddScoped<IPatronLuzRepository, PatronLuzRepository>();
        }
        public static void ReglasNegocioService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPatronLuzService, PatronLuzService>();
        }
    }
}
