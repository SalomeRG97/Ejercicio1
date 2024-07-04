using Ejercicio1.Api;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Ejercicio1.Models;
using Ejercicio1.Api.ServiceCall;

namespace UI.Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiLucesController _apiLucesController;

        public HomeController(IApiLucesController apiLucesController)
        {
            _apiLucesController = apiLucesController;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var patron = await _apiLucesController.Get();
                return View(patron);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("ErrorBadRequest");
            }
        }
        [HttpGet("Medicion/{Id}")]
        public async Task<IActionResult> Medicion([FromRoute] int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var patron = await _apiLucesController.GetByCode(Id);

                    if (patron == null)
                    {
                        ModelState.AddModelError(string.Empty, "El patrón no existe");
                        return View("Index");
                    }

                    return View(patron);
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("ErrorBadRequest");
            }
        }
        [HttpPost("Validar")]
        public async Task<IActionResult> Validar(MiViewModel patron)
        {
            try
            {
                var model = new MedicionLuces
                {
                    Int_Baja_Izq_1 = patron.Int_Baja_Izq_1_Med,
                    Inc_Baja_Izq_1 = patron.Inc_Baja_Izq_1_Med,
                    Int_Baja_Der_1 = patron.Int_Baja_Der_1_Med
                };
                var result = await _apiLucesController.Validar(model, patron.Id);
                return View("Resultados", result);


            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("ErrorBadRequest");
            }
        }
    }
}
