using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Ejercicio1.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LucesController : ControllerBase
    {
        //private readonly PatronLuces _patronLuces = new PatronLuces
        //{
        //    Int_Baja_Izq_1 = true,
        //    Inc_Baja_Izq_1 = false,
        //    Int_Baja_Der_1 = true
        //};

        [HttpPost("validar")]
        public IActionResult Validar(PatronLuces patron)
        {
            var resultado = new ResultadoValidacion();
            var medicionLuces = new MedicionLuces();

            ValidarPropiedad(nameof(patron.Int_Baja_Izq_1), patron.Int_Baja_Izq_1, medicionLuces, resultado);
            ValidarPropiedad(nameof(patron.Inc_Baja_Izq_1), patron.Inc_Baja_Izq_1, medicionLuces, resultado);
            ValidarPropiedad(nameof(patron.Int_Baja_Der_1), patron.Int_Baja_Der_1, medicionLuces, resultado);
            resultado.MedicionLuces = medicionLuces;

            return Ok(resultado);
        }

        private void ValidarPropiedad(string nombrePropiedad, bool patronValor, MedicionLuces medicionLuces, ResultadoValidacion resultado)
        {
            PropertyInfo propertyInfo = typeof(MedicionLuces).GetProperty(nombrePropiedad);
            var nuevoValor = ObtenerValorMedicion(nombrePropiedad);

            if (patronValor)
            {
                propertyInfo.SetValue(medicionLuces, nuevoValor);
                resultado.LucesConMedicionNoRequerida.Add(nombrePropiedad);
            }
            else
            {
                propertyInfo.SetValue(medicionLuces, null);
                resultado.LucesConMedicionRequerida.Add(nombrePropiedad);
            }
        }
        private decimal? ObtenerValorMedicion(string nombrePropiedad)
        {
            return new decimal?(123.45M);
        }
    }
}
