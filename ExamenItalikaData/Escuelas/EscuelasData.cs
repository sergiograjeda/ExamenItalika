using ExamenItalika.Data;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExamenItalikaData.Escuelas
{
	public class EscuelasData : IEscuelasData
	{
		private readonly IConfiguration _configuration;
		private string _connectionString = "ConnectionStrings:default";
		private string storedProcedureName = "sp_Escuela_CRUD";

		public EscuelasData(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public int CreateEscuela(ExamenItalika.Models.DTO.Escuela escuela)
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			int resultado = 0;

			using (var connection = dbConnection.GetConnection())
			{
				try
				{
					connection.Open();

					using (var command = connection.CreateCommand())
					{
						command.CommandText = storedProcedureName;
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar) { Value = "INSERT" });
						command.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar) { Value = escuela.Codigo });
						command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = escuela.Nombre });
						command.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = escuela.Descripcion });


						using (var reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								resultado = int.Parse(reader[0]?.ToString());
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
			return resultado;
		}

		public ExamenItalika.Models.DTO.Escuela GetEscuelaById(int id)
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			ExamenItalika.Models.DTO.Escuela resultado = new ExamenItalika.Models.DTO.Escuela();

			using (var connection = dbConnection.GetConnection())
			{
				try
				{
					connection.Open();

					using (var command = connection.CreateCommand())
					{
						command.CommandText = storedProcedureName;
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar) { Value = "SELECT" });
						command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });


						using (var reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								resultado.Id = int.Parse(reader["Id"]?.ToString());
								resultado.Codigo = reader["Codigo"]?.ToString();
								resultado.Nombre = reader["Nombre"]?.ToString();
								resultado.Descripcion = reader["Descripcion"]?.ToString();
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
			return resultado;
		}

		public List<ExamenItalika.Models.DTO.Escuela> GetEscuelasList()
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			List<ExamenItalika.Models.DTO.Escuela> resultado = new List<ExamenItalika.Models.DTO.Escuela>();

			using (var connection = dbConnection.GetConnection())
			{
				try
				{
					connection.Open();

					using (var command = connection.CreateCommand())
					{
						command.CommandText = storedProcedureName;
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar) { Value = "LIST" });


						using (var reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								var escuela = new ExamenItalika.Models.DTO.Escuela();

								escuela.Id = int.Parse(reader["Id"]?.ToString());
								escuela.Codigo = reader["Codigo"]?.ToString();
								escuela.Nombre = reader["Nombre"]?.ToString();
								escuela.Descripcion = reader["Descripcion"]?.ToString();

								resultado.Add(escuela);
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
			return resultado;
		}

		public ExamenItalika.Models.DTO.Escuela UpdateEscuela(ExamenItalika.Models.DTO.Escuela escuela)
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			ExamenItalika.Models.DTO.Escuela resultado = new ExamenItalika.Models.DTO.Escuela();

			using (var connection = dbConnection.GetConnection())
			{
				try
				{
					connection.Open();

					using (var command = connection.CreateCommand())
					{
						command.CommandText = storedProcedureName;
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar) { Value = "UPDATE" });
						command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = escuela.Id });
						command.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar) { Value = escuela.Codigo });
						command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = escuela.Nombre });
						command.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = escuela.Descripcion });


						using (var reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								resultado = escuela;
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
			return resultado;
		}

		public bool DeleteEscuela(int id)
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			bool resultado = false;

			using (var connection = dbConnection.GetConnection())
			{
				try
				{
					connection.Open();

					using (var command = connection.CreateCommand())
					{
						command.CommandText = storedProcedureName;
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar) { Value = "DELETE" });
						command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });


						using (var reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								resultado = bool.Parse(reader[0]?.ToString());
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
			return resultado;
		}
	}
}
