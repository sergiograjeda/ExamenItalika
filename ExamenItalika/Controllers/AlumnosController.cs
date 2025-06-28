using ExamenItalika.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenItalika.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AlumnosController : ControllerBase
	{
		private readonly AppDbContext _context;
		public AlumnosController(AppDbContext context) => _context = context;

		[HttpGet("profesores/{profesorId}/alumnos")]
		public IActionResult GetAlumnosByProfesor(int profesorId)
		{
			var alumnos = _context.Alumnos
				.Where(a => a.ProfesorId == profesorId)
				.Include(a => a.Profesor)
				.ThenInclude(p => p.Escuela)
				.ToList();

			return Ok(alumnos);
		}
	}
}
