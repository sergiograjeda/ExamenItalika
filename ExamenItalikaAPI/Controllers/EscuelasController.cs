using ExamenItalika.Models.DTO;
using ExamenItalikaServices.Escuelas;
using Microsoft.AspNetCore.Mvc;

namespace ExamenItalika.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EscuelasController : ControllerBase
	{
		IEscuelasServices _escuelasServices;

		public EscuelasController(IEscuelasServices escuelasServices)
		{
			_escuelasServices = escuelasServices;
		}

		[HttpPost("/Escuelas/Create")]
		public IActionResult CreateEscuela([FromBody] Escuela escuela)
		{
			var Escuelas = _escuelasServices.CreateEscuela(escuela);

			return Ok(Escuelas);
		}

		[HttpGet("/Escuelas/ById/{id}")]
		public IActionResult GetEscuelaById(int id)
		{
			var Escuelas = _escuelasServices.GetEscuelaById(id);

			return Ok(Escuelas);
		}

		[HttpGet("/Escuelas/List")]
		public IActionResult GetEscuelas()
		{
			var Escuelas = _escuelasServices.GetEscuelasList();

			return Ok(Escuelas);
		}

		[HttpPut("/Escuelas/Update")]
		public IActionResult UpdateEscuela([FromBody] Escuela escuela)
		{
			var Escuelas = _escuelasServices.UpdateEscuela(escuela);

			return Ok(Escuelas);
		}

		[HttpDelete("/Escuelas/Delete/{id}")]
		public IActionResult DeleteEscuela(int id)
		{
			var escuela = _escuelasServices.DeleteEscuela(id);

			return Ok(escuela);
		}
	}
}
