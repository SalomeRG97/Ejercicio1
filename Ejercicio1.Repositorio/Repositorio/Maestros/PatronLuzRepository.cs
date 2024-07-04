using AutoMapper;
using Ejercicio1.Entidades;
using Ejercicio1.Interfaces;

namespace Ejercicio1.Repositorio.Repositorio.Maestros
{
    public class PatronLuzRepository : Repository<PatronLuce>, IPatronLuzRepository
    {
        public PatronLuzRepository(EjerciciosContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
