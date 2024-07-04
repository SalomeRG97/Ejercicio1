using Ejercicio1.Interfaces;
using Ejercicio1.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Api.Controllers.Maestros
{
    public class PatronLuzController : Controller
    {
        private readonly IPatronLuzService _patronLuzService;

        public PatronLuzController(IPatronLuzService patronLuzService)
        {
            _patronLuzService = patronLuzService;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var dto = await _patronLuzService.GetAll();
            return Ok(new { Result = dto });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreatePatronLuzDTO dto)
        {
            await _patronLuzService.Add(dto);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(PatronLuzDTO dto)
        {
            await _patronLuzService.Update(dto);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(PatronLuzDTO dto)
        {
            await _patronLuzService.Delete(dto);
            return Ok();
        }
    }
}
