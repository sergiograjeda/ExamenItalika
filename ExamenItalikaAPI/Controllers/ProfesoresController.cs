using ExamenItalika.Models.DTO;
using ExamenItalikaServices.Profesores;
using Microsoft.AspNetCore.Mvc;

namespace ExamenItalika.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProfesoresController : ControllerBase
	{
		IProfesoresServices _profesoresServices;

		public ProfesoresController(IProfesoresServices profesoresServices)
		{
			_profesoresServices = profesoresServices;
		}

		[HttpPost("/Profesores/Create")]
		public IActionResult CreateProfesor([FromBody] Profesor Profesor)
		{
			var Profesores = _profesoresServices.CreateProfesor(Profesor);

			return Ok(Profesores);
		}

		[HttpGet("/Profesores/ById/{id}")]
		public IActionResult GetProfesorById(int id)
		{
			var Profesores = _profesoresServices.GetProfesorById(id);

			return Ok(Profesores);
		}

		[HttpGet("/Profesores/List")]
		public IActionResult GetProfesores()
		{
			var Profesores = _profesoresServices.GetProfesoresList();

			return Ok(Profesores);
		}

		[HttpPut("/Profesores/Update")]
		public IActionResult UpdateProfesor([FromBody] Profesor Profesor)
		{
			var Profesores = _profesoresServices.UpdateProfesor(Profesor);

			return Ok(Profesores);
		}

		[HttpDelete("/Profesores/Delete/{id}")]
		public IActionResult DeleteProfesor(int id)
		{
			var Profesores = _profesoresServices.DeleteProfesor(id);

			return Ok(Profesores);
		}
	}
}
