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

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Validar")]
        public async Task<IActionResult> Validar(PatronLuces patron)
        {
            var result = await _apiLucesController.Validar(patron);

            if (result == null)
            {
                TempData["SuccessMessage"] = "Recurso creado exitosamente";
                return Redirect("/Home");
            }

            return View("Resultados", result);
        }
    }
}
