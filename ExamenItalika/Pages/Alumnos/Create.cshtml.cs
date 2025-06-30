using ExamenItalikaModels.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace ExamenItalika.Pages.Alumnos
{
    public class CreateModel : PageModel
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public CreateModel(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[BindProperty]
		public Models.DTO.Alumno Alumno { get; set; }
		[BindProperty]
		public List<Models.DTO.Profesor> Profesores { get; set; }

		public readonly string Modulo = "Alumnos";
		public readonly string Accion = "Crear";
		public string ActionResultMessage { get; set; }

		public IActionResult OnGet()
		{
			Alumno = GetAlumnoByIdAsync().Result;
			Profesores = GetProfesoresAsync().Result;
			return Page();
		}

		private async Task<Models.DTO.Alumno> GetAlumnoByIdAsync()
		{
			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.GetAsync("/Alumnos/ById");

			if (response.IsSuccessStatusCode)
			{
				var alumno = await response.Content.ReadFromJsonAsync<Models.DTO.Alumno>();
				return alumno;
			}
			else
			{
				return new Models.DTO.Alumno();
			}
		}

		private async Task<List<Models.DTO.Profesor>> GetProfesoresAsync()
		{
			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.GetAsync("/Profesores/List");

			if (response.IsSuccessStatusCode)
			{
				var profesores = await response.Content.ReadFromJsonAsync<List<Models.DTO.Profesor>>();
				return profesores;
			}
			else
			{
				return new List<Models.DTO.Profesor>();
			}
		}

		public async Task<IActionResult> OnPostAsync()
		{
			ModelState.Remove("Alumno.ProfesorNombre");
			if (!ModelState.IsValid)
			{
				return Page();
			}

			string json = JsonSerializer.Serialize(Alumno);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.PostAsync("/Alumnos/Create", content);

			if (response.IsSuccessStatusCode)
			{
				var alumno = await response.Content.ReadFromJsonAsync<int>();
				ActionResultMessage = Constantes.exitoCrear;
				return Page();
			}
			else
			{
				return BadRequest();
			}

		}
	}
}
