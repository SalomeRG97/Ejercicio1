using AutoMapper;
using Ejercicio1.DTO;
using Ejercicio1.Entidades;

namespace Configuraciones.Automapper
{
    public class Ejercicio1_MappingProfile : Profile
    {
        public Ejercicio1_MappingProfile()
        {
            CreateMap<CreateMedicionLuzDTO, MedicionLuce>().ReverseMap();
            CreateMap<MedicionLuzDTO, MedicionLuce>().ReverseMap();
            CreateMap<PatronLuzDTO, PatronLuce>().ReverseMap();
            CreateMap<CreatePatronLuzDTO, PatronLuce>().ReverseMap();
        }
    }
}
