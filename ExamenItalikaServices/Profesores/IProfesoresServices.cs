using ExamenItalika.Models.DTO;

namespace ExamenItalikaServices.Profesores
{
	public interface IProfesoresServices
	{
		int CreateProfesor(Profesor profesor);
		Profesor GetProfesorById(int id);
		List<Profesor> GetProfesoresList();
		Profesor UpdateProfesor(Profesor profesor);
		bool DeleteProfesor(int id);
	}
}
