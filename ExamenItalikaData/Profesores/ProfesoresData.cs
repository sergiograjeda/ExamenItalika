using ExamenItalika.Data;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExamenItalikaData.Profesores
{
	public class ProfesoresData : IProfesoresData
	{
		private readonly IConfiguration _configuration;
		private string _connectionString = "ConnectionStrings:default";
		private string storedProcedureName = "sp_Profesor_CRUD";

		public ProfesoresData(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public int CreateProfesor(ExamenItalika.Models.DTO.Profesor profesor)
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
						command.Parameters.Add(new SqlParameter("@Identificacion", SqlDbType.VarChar) { Value = profesor.Identificacion });
						command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = profesor.Nombre });
						command.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = profesor.Apellido });
						command.Parameters.Add(new SqlParameter("@EscuelaId", SqlDbType.Int) { Value = profesor.EscuelaId });


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

		public ExamenItalika.Models.DTO.Profesor GetProfesorById(int id)
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			ExamenItalika.Models.DTO.Profesor resultado = new ExamenItalika.Models.DTO.Profesor();

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
								resultado.Identificacion = reader["Identificacion"]?.ToString();
								resultado.Nombre = reader["Nombre"]?.ToString();
								resultado.Apellido = reader["Apellido"]?.ToString();
								resultado.EscuelaNombre = reader["EscuelaNombre"]?.ToString();
								resultado.EscuelaId = int.Parse(reader["EscuelaId"]?.ToString());
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

		public List<ExamenItalika.Models.DTO.Profesor> GetProfesoresList()
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			List<ExamenItalika.Models.DTO.Profesor> resultado = new List<ExamenItalika.Models.DTO.Profesor>();

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
								var profesor = new ExamenItalika.Models.DTO.Profesor();

								profesor.Id = int.Parse(reader["Id"]?.ToString());
								profesor.Identificacion = reader["Identificacion"]?.ToString();
								profesor.Nombre = reader["Nombre"]?.ToString();
								profesor.Apellido = reader["Apellido"]?.ToString();
								profesor.EscuelaNombre = reader["EscuelaNombre"]?.ToString();

								resultado.Add(profesor);
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

		public ExamenItalika.Models.DTO.Profesor UpdateProfesor(ExamenItalika.Models.DTO.Profesor profesor)
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			ExamenItalika.Models.DTO.Profesor resultado = new ExamenItalika.Models.DTO.Profesor();

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
						command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = profesor.Id });
						command.Parameters.Add(new SqlParameter("@Identificacion", SqlDbType.VarChar) { Value = profesor.Identificacion });
						command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = profesor.Nombre });
						command.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = profesor.Apellido });
						command.Parameters.Add(new SqlParameter("@EscuelaId", SqlDbType.Int) { Value = profesor.EscuelaId });


						using (var reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								resultado = profesor;
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

		public bool DeleteProfesor(int id)
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
