
using ExamenItalika.Models.DTO;
using ExamenItalikaServices.Alumnos;
using Microsoft.AspNetCore.Mvc;

namespace ExamenItalika.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AlumnosController : ControllerBase
	{
		IAlumnosServices _alumnosServices;

		public AlumnosController(IAlumnosServices alumnosServices)
		{
			_alumnosServices = alumnosServices;
		}

		[HttpPost("/Alumnos/Create")]
		public IActionResult CreateAlumno([FromBody] Alumno alumno)
		{
			var alumnos = _alumnosServices.CreateAlumno(alumno);

			return Ok(alumnos);
		}

		[HttpGet("/Alumnos/ById/{id}")]
		public IActionResult GetAlumnoById(int id)
		{
			var alumnos = _alumnosServices.GetAlumnoById(id);

			return Ok(alumnos);
		}

		[HttpGet("/Alumnos/List")]
		public IActionResult GetAlumnos()
		{
			var alumnos = _alumnosServices.GetAlumnosList();

			return Ok(alumnos);
		}

		[HttpPut("/Alumnos/Update")]
		public IActionResult UpdateAlumno([FromBody] Alumno alumno)
		{
			var alumnos = _alumnosServices.UpdateAlumno(alumno);

			return Ok(alumnos);
		}

		[HttpDelete("/Alumnos/Delete/{id}")]
		public IActionResult DeleteAlumno(int id)
		{
			var alumnos = _alumnosServices.DeleteAlumno(id);

			return Ok(alumnos);
		}
	}
}
