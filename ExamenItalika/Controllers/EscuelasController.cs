using ExamenItalika.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenItalika.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EscuelasController : ControllerBase
	{
		private readonly AppDbContext _context;
		public EscuelasController(AppDbContext context) => _context = context;

		[HttpGet]
		public IActionResult GetAll() => Ok(_context.Escuelas.Include(e => e.Profesores));
	}
}
