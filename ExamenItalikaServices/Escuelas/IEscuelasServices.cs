using ExamenItalika.Models.DTO;

namespace ExamenItalikaServices.Escuelas
{
	public interface IEscuelasServices
	{
		int CreateEscuela(Escuela escuela);
		Escuela GetEscuelaById(int id);
		List<Escuela> GetEscuelasList();
		Escuela UpdateEscuela(Escuela escuela);
		bool DeleteEscuela(int id);
	}
}
