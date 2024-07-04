using AutoMapper;
using Ejercicio1.Entidades;
using Ejercicio1.Interfaces;

namespace Ejercicio1.Repositorio
{
    public class MedicionLuzRepository : Repository<MedicionLuce>, IMedicionLuzRepository
    {
        public MedicionLuzRepository(EjerciciosContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
