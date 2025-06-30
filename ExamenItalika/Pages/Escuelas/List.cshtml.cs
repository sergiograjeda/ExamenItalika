using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamenItalika.Pages.Escuelas
{
    public class ListModel : PageModel
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public ListModel(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IEnumerable<Models.DTO.Escuela> Escuelas = new List<Models.DTO.Escuela>();
		public readonly string Modulo = "Escuelas";
		public IActionResult OnGet()
		{
			Escuelas = GetEscuelasAsync().Result;
			return Page();
		}

		private async Task<IEnumerable<Models.DTO.Escuela>> GetEscuelasAsync()
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
	}
}
