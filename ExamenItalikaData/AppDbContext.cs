using System.Data;
using System.Data.SqlClient;

namespace ExamenItalika.Data
{
	public class AppDbContext
	{
		private string _connectionString;
		public AppDbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public IDbConnection GetConnection()
		{
			return new SqlConnection(_connectionString);
		}
	}
}
