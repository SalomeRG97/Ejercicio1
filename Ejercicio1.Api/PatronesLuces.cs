namespace Ejercicio1.Api
{
    public class PatronesLuces
    {
        public List<PatronLuces> Patrones { get; set; }

        public PatronesLuces()
        {
            Patrones = new List<PatronLuces>
        {
            new PatronLuces
            {
                Id = 1,
                Int_Baja_Izq_1 = false,
                Inc_Baja_Izq_1 = false,
                Int_Baja_Der_1 = true
            },
            new PatronLuces
            {
                Id = 2,
                Int_Baja_Izq_1 = true,
                Inc_Baja_Izq_1 = false,
                Int_Baja_Der_1 = true
            }
        };
        }
    }

}
