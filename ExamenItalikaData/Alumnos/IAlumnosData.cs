using ExamenItalika.Models.DTO;

namespace ExamenItalikaData.Alumnos
{
	public interface IAlumnosData
	{
		int CreateAlumno(ExamenItalika.Models.DTO.Alumno alumno);
		ExamenItalika.Models.DTO.Alumno GetAlumnoById(int id);
		List<ExamenItalika.Models.DTO.Alumno> GetAlumnosList();
		ExamenItalika.Models.DTO.Alumno UpdateAlumno(ExamenItalika.Models.DTO.Alumno alumno);
		bool DeleteAlumno(int id);
	}
}
