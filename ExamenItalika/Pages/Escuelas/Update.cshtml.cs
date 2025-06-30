using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace ExamenItalika.Pages.Escuelas
{
	public class UpdateModel : PageModel
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public UpdateModel(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[BindProperty]
		public Models.DTO.Escuela Escuela { get; set; }

		public readonly string Modulo = "Escuelas";
		public readonly string Accion = "Editar";

		public IActionResult OnGet(int id)
		{
			Escuela = GetEscuelaByIdAsync(id).Result;
			return Page();
		}

		private async Task<Models.DTO.Escuela> GetEscuelaByIdAsync(int id)
		{
			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.GetAsync("/Escuelas/ById/" + id);

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
			var response = await client.PutAsync("/Escuelas/Update", content);

			if (response.IsSuccessStatusCode)
			{
				var escuela = await response.Content.ReadFromJsonAsync<Models.DTO.Escuela>();
				return Page();
			}
			else
			{
				return BadRequest();
			}

		}
	}
}
