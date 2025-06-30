using ExamenItalika.Models.DTO;

namespace ExamenItalikaServices.Alumnos
{
	public interface IAlumnosServices
	{
		int CreateAlumno(Alumno alumno);
		Alumno GetAlumnoById(int id);
		List<Alumno> GetAlumnosList();
		Alumno UpdateAlumno(Alumno alumno);
		bool DeleteAlumno(int id);
	}
}
