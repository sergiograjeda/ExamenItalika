﻿namespace ExamenItalika.Models.DTO
{
	public class Alumno
	{
		public int Id { get; set; }
		public string Identificacion { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string? ProfesorNombre { get; set; }
		public int ProfesorId { get; set; }
	}
}
