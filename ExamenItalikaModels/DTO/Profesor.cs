namespace ExamenItalika.Models.DTO
{
	public class Profesor
	{
		public int Id { get; set; }
		public string Identificacion { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public int EscuelaId { get; set; }
		public string? EscuelaNombre { get; set; }
	}
}
