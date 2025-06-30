using ExamenItalika.Models.DTO;
using ExamenItalikaData.Profesores;

namespace ExamenItalikaServices.Profesores
{
	public class ProfesoresServices: IProfesoresServices
	{
		IProfesoresData _profesoresData;
		public ProfesoresServices(IProfesoresData profesoresData)
		{
			_profesoresData = profesoresData;
		}

		public int CreateProfesor(Profesor profesor)
		{
			var result = _profesoresData.CreateProfesor(profesor);
			return result;
		}

		public Profesor GetProfesorById(int id)
		{
			var result = _profesoresData.GetProfesorById(id);
			return result;
		}

		public List<Profesor> GetProfesoresList()
		{
			var result = _profesoresData.GetProfesoresList();
			return result;
		}
		public Profesor UpdateProfesor(Profesor profesor)
		{
			var result = _profesoresData.UpdateProfesor(profesor);
			return result;
		}

		public bool DeleteProfesor(int id)
		{
			var result = _profesoresData.DeleteProfesor(id);
			return result;
		}
	}
}
