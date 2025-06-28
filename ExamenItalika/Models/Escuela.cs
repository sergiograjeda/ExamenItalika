namespace ExamenItalika.Models
{
	public class Escuela
	{
		public int Id { get; set; }
		public string Codigo { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public ICollection<Profesor> Profesores { get; set; } = new List<Profesor>();
	}
}
