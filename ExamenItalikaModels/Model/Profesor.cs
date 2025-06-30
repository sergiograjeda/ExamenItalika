namespace ExamenItalika.Models.Model
{
	public class Profesor
	{
		public int Id { get; set; }
		public string Identificacion { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public int EscuelaId { get; set; }
		public Escuela Escuela { get; set; }
		public ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
	}
}
