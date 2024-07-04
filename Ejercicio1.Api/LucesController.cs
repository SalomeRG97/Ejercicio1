using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio1.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LucesController : ControllerBase
    {
        private readonly PatronesLuces _patronesLuces;

        public LucesController()
        {
            _patronesLuces = new PatronesLuces();
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(_patronesLuces.Patrones);
        }
        [HttpGet("GetByCode/{id}")]
        public async Task<IActionResult> GetByCode(int id)
        {
            var patron = _patronesLuces.Patrones.FirstOrDefault(p => p.Id == id);

            if (patron == null)
            {
                return NotFound($"Patrón con ID {id} no encontrado.");
            }

            return Ok(patron);
        }

        [HttpPost("validar/{id}")]

        public IActionResult Validar(MedicionLuces medicion, int id)
        {
            PatronLuces patron;

            try
            {
                var resultado = new ResultadoValidacion();
                resultado.MedicionLuces = new MedicionLuces();

                // Selección del patrón
                if (id == 1)
                {
                    patron = _patronesLuces.Patrones.FirstOrDefault(p => p.Id == 1);
                }
                else if (id == 2)
                {
                    patron = _patronesLuces.Patrones.FirstOrDefault(p => p.Id == 2);
                }
                else
                {
                    return BadRequest("Patrón no válido seleccionado.");
                }

                // Validación de propiedades
                ValidarPropiedad(nameof(medicion.Int_Baja_Izq_1), medicion.Int_Baja_Izq_1, patron.Int_Baja_Izq_1, resultado);
                ValidarPropiedad(nameof(medicion.Inc_Baja_Izq_1), medicion.Inc_Baja_Izq_1, patron.Inc_Baja_Izq_1, resultado);
                ValidarPropiedad(nameof(medicion.Int_Baja_Der_1), medicion.Int_Baja_Der_1, patron.Int_Baja_Der_1, resultado);

                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void ValidarPropiedad(string nombrePropiedad, decimal? medicionValor, bool patronValor, ResultadoValidacion resultado)
        {
            PropertyInfo propertyInfo = typeof(MedicionLuces).GetProperty(nombrePropiedad);
            if (patronValor)
            {
                if (medicionValor == null)
                {
                    throw new InvalidOperationException($"El valor para {nombrePropiedad} no puede ser null.");
                }
                propertyInfo.SetValue(resultado.MedicionLuces, medicionValor);
                resultado.LucesConMedicionNoRequerida.Add(nombrePropiedad);
            }
            else
            {
                if (medicionValor != null)
                {
                    throw new InvalidOperationException($"El valor para {nombrePropiedad} debe ser null.");
                }
                propertyInfo.SetValue(resultado.MedicionLuces, medicionValor);
                resultado.LucesConMedicionRequerida.Add(nombrePropiedad);
            }
        }

    }
}
