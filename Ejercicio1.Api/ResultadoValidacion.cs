namespace Ejercicio1.Api
{
    public class ResultadoValidacion
    {
        public List<string> LucesConMedicionRequerida { get; } = new List<string>();
        public List<string> LucesConMedicionNoRequerida { get; } = new List<string>();
        public MedicionLuces MedicionLuces { get; set; }

    }
}
