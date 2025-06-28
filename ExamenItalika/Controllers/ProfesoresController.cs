using ExamenItalika.Data;
using ExamenItalika.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenItalika.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProfesoresController : ControllerBase
	{
		private readonly AppDbContext _context;
		public ProfesoresController(AppDbContext context) => _context = context;

		[HttpPost("{escuelaId}/profesores")]
		public IActionResult AddProfesor(int escuelaId, Profesor profesor)
		{
			var escuela = _context.Escuelas.Find(escuelaId);
			if (escuela == null) return NotFound();

			profesor.EscuelaId = escuelaId;
			_context.Profesores.Add(profesor);
			_context.SaveChanges();

			return CreatedAtAction(nameof(GetProfesor), new { id = profesor.Id }, profesor);
		}
	}
}
