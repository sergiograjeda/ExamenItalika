using ExamenItalika.Models.DTO;

namespace ExamenItalikaData.Profesores
{
	public interface IProfesoresData
	{
		int CreateProfesor(Profesor profesor);
		Profesor GetProfesorById(int id);
		List<Profesor> GetProfesoresList();
		Profesor UpdateProfesor(Profesor profesor);
		bool DeleteProfesor(int id);
	}
}
