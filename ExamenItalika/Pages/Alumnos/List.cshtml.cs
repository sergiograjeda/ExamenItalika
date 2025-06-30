using ExamenItalika.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamenItalika.Pages.Alumnos
{
    public class ListModel : PageModel
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public ListModel(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IEnumerable<Models.DTO.Alumno> Alumnos = new List<Models.DTO.Alumno>();
		public readonly string Modulo = "Alumnos";
		public IActionResult OnGet()
		{
			Alumnos = GetAlumnosAsync().Result;
			return Page();
		}

		private async Task<IEnumerable<Models.DTO.Alumno>> GetAlumnosAsync()
		{
			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.GetAsync("/Alumnos/List");

			if (response.IsSuccessStatusCode)
			{
				var alumnos = await response.Content.ReadFromJsonAsync<List<Models.DTO.Alumno>>();
				return alumnos;
			}
			else
			{
				return new List<Models.DTO.Alumno>();
			}
		}
	}
}
