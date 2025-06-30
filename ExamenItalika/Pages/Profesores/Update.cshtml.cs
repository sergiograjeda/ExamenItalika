using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace ExamenItalika.Pages.Profesores
{
	public class UpdateModel : PageModel
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public UpdateModel(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[BindProperty]
		public Models.DTO.Profesor Profesor { get; set; }
		[BindProperty]
		public List<Models.DTO.Escuela> Escuelas { get; set; }

		public readonly string Modulo = "Profesores";
		public readonly string Accion = "Editar";
		public IActionResult OnGet(int id)
		{
			Profesor = GetProfesorByIdAsync(id).Result;
			Escuelas = GetEscuelasAsync().Result;
			return Page();
		}

		private async Task<Models.DTO.Profesor> GetProfesorByIdAsync(int id)
		{
			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.GetAsync("/Profesores/ById/" + id);

			if (response.IsSuccessStatusCode)
			{
				var profesor = await response.Content.ReadFromJsonAsync<Models.DTO.Profesor>();
				return profesor;
			}
			else
			{
				return new Models.DTO.Profesor();
			}
		}

		private async Task<List<Models.DTO.Escuela>> GetEscuelasAsync()
		{
			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.GetAsync("/Escuelas/List");

			if (response.IsSuccessStatusCode)
			{
				var escuelas = await response.Content.ReadFromJsonAsync<List<Models.DTO.Escuela>>();
				return escuelas;
			}
			else
			{
				return new List<Models.DTO.Escuela>();
			}
		}

		public async Task<IActionResult> OnPostAsync()
		{
			ModelState.Remove("Escuelas.EscuelaNombre");
			if (!ModelState.IsValid)
			{
				return Page();
			}

			string json = JsonSerializer.Serialize(Profesor);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var client = _httpClientFactory.CreateClient("MyApi");
			var response = await client.PutAsync("/Profesores/Update", content);

			if (response.IsSuccessStatusCode)
			{
				var profesor = await response.Content.ReadFromJsonAsync<Models.DTO.Profesor>();
				return Page();
			}
			else
			{
				return BadRequest();
			}

		}
	}
}
