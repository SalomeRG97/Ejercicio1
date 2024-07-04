using System.ComponentModel.DataAnnotations;

namespace Ejercicio1.Api
{
    public class MiViewModel
    {
        public int Id { get; set; }

        public bool Int_Baja_Izq_1 { get; set; }
        public bool Inc_Baja_Izq_1 { get; set; }
        public bool Int_Baja_Der_1 { get; set; }

        public decimal? Int_Baja_Izq_1_Med { get; set; } 
        public decimal? Inc_Baja_Izq_1_Med { get; set; }
        public decimal? Int_Baja_Der_1_Med { get; set; }
    }

}
