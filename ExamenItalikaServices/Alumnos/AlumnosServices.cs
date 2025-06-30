using ExamenItalika.Models.DTO;
using ExamenItalikaData.Alumnos;

namespace ExamenItalikaServices.Alumnos
{
	public class AlumnosServices : IAlumnosServices
	{
		IAlumnosData _alumnosData;
		public AlumnosServices(IAlumnosData alumnosData)
		{
			_alumnosData = alumnosData;
		}

		public int CreateAlumno(Alumno alumno)
		{
			var result = _alumnosData.CreateAlumno(alumno);
			return result;
		}

		public Alumno GetAlumnoById(int id)
		{
			var result = _alumnosData.GetAlumnoById(id);
			return result;
		}

		public List<Alumno> GetAlumnosList()
		{
			var result = _alumnosData.GetAlumnosList();
			return result;
		}
		public Alumno UpdateAlumno(Alumno alumno)
		{
			var result = _alumnosData.UpdateAlumno(alumno);
			return result;
		}

		public bool DeleteAlumno(int id)
		{
			var result = _alumnosData.DeleteAlumno(id);
			return result;
		}
	}
}
