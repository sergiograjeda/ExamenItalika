using ExamenItalika.Models.DTO;
using ExamenItalikaData.Escuelas;

namespace ExamenItalikaServices.Escuelas
{
	public class EscuelasServices: IEscuelasServices
	{
		IEscuelasData _escuelasData;
		public EscuelasServices(IEscuelasData escuelasData)
		{
			_escuelasData = escuelasData;
		}

		public int CreateEscuela(Escuela escuela)
		{
			var result = _escuelasData.CreateEscuela(escuela);
			return result;
		}

		public Escuela GetEscuelaById(int id)
		{
			var result = _escuelasData.GetEscuelaById(id);
			return result;
		}

		public List<Escuela> GetEscuelasList()
		{
			var result = _escuelasData.GetEscuelasList();
			return result;
		}
		public Escuela UpdateEscuela(Escuela escuela)
		{
			var result = _escuelasData.UpdateEscuela(escuela);
			return result;
		}

		public bool DeleteEscuela(int id)
		{
			var result = _escuelasData.DeleteEscuela(id);
			return result;
		}
	}
}
