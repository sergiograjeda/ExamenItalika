using ExamenItalika.Models.DTO;

namespace ExamenItalikaData.Escuelas
{
	public interface IEscuelasData
	{
		int CreateEscuela(Escuela escuela);
		Escuela GetEscuelaById(int id);
		List<Escuela> GetEscuelasList();
		Escuela UpdateEscuela(Escuela escuela);
		bool DeleteEscuela(int id);
	}
}
