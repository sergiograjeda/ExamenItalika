using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace ExamenItalika.Pages.Escuelas
{
    public class CreateModel : PageModel
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public CreateModel(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[BindProperty]
		public Models.DTO.Escuela Escuela { get; set; }

		public readonly string Modulo = "Escuelas";
		public readonly string Accion = "Crear";

		public IActionResult OnGet()
		{
			Escuela = GetEscuelaByIdAsync().Result;
			return Page();
		}

		private async Task<Models.DTO.Escuela> GetEscuelaByIdAsync()
		{
			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.GetAsync("/Escuelas/ById");

			if (response.IsSuccessStatusCode)
			{
				var escuela = await response.Content.ReadFromJsonAsync<Models.DTO.Escuela>();
				return escuela;
			}
			else
			{
				return new Models.DTO.Escuela();
			}
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			string json = JsonSerializer.Serialize(Escuela);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.PostAsync("/Escuelas/Create", content);

			if (response.IsSuccessStatusCode)
			{
				var escuela = await response.Content.ReadFromJsonAsync<int>();
				return Page();
			}
			else
			{
				return BadRequest();
			}

		}
	}
}
