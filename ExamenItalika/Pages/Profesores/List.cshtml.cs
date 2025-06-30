using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamenItalika.Pages.Profesores
{
    public class ListModel : PageModel
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public ListModel(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IEnumerable<Models.DTO.Profesor> Profesores = new List<Models.DTO.Profesor>();
		public readonly string Modulo = "Profesores";
		public IActionResult OnGet()
		{
			Profesores = GetProfesoresAsync().Result;
			return Page();
		}

		private async Task<IEnumerable<Models.DTO.Profesor>> GetProfesoresAsync()
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
	}
}
