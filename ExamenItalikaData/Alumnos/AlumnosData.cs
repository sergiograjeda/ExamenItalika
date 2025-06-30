using ExamenItalika.Data;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExamenItalikaData.Alumnos
{
	public class AlumnosData : IAlumnosData
	{
		private readonly IConfiguration _configuration;
		private string _connectionString = "ConnectionStrings:default";
		private string storedProcedureName = "sp_Alumnos_CRUD";

		public AlumnosData(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public int CreateAlumno(ExamenItalika.Models.DTO.Alumno alumno)
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
						command.Parameters.Add(new SqlParameter("@Identificacion", SqlDbType.VarChar) { Value = alumno.Identificacion });
						command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = alumno.Nombre });
						command.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = alumno.Apellido });
						command.Parameters.Add(new SqlParameter("@FechaNacimiento", SqlDbType.Date) { Value = alumno.FechaNacimiento });
						command.Parameters.Add(new SqlParameter("@ProfesorId", SqlDbType.Int) { Value = alumno.ProfesorId });


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

		public ExamenItalika.Models.DTO.Alumno GetAlumnoById(int id)
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			ExamenItalika.Models.DTO.Alumno resultado = new ExamenItalika.Models.DTO.Alumno();

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
								resultado.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"]?.ToString());
								resultado.ProfesorNombre = reader["ProfesorNombre"]?.ToString();
								resultado.ProfesorId = int.Parse(reader["ProfesorId"]?.ToString());
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

		public List<ExamenItalika.Models.DTO.Alumno> GetAlumnosList()
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			List<ExamenItalika.Models.DTO.Alumno> resultado = new List<ExamenItalika.Models.DTO.Alumno>();

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
								var alumno = new ExamenItalika.Models.DTO.Alumno();

								alumno.Id = int.Parse(reader["Id"]?.ToString());
								alumno.Identificacion = reader["Identificacion"]?.ToString();
								alumno.Nombre = reader["Nombre"]?.ToString();
								alumno.Apellido = reader["Apellido"]?.ToString();
								alumno.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"]?.ToString());
								alumno.ProfesorNombre = reader["ProfesorNombre"]?.ToString();

								resultado.Add(alumno);
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

		public ExamenItalika.Models.DTO.Alumno UpdateAlumno(ExamenItalika.Models.DTO.Alumno alumno)
		{
			var dbConnection = new AppDbContext(_configuration[_connectionString]);
			ExamenItalika.Models.DTO.Alumno resultado = new ExamenItalika.Models.DTO.Alumno();

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
						command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = alumno.Id });
						command.Parameters.Add(new SqlParameter("@Identificacion", SqlDbType.VarChar) { Value = alumno.Identificacion });
						command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = alumno.Nombre });
						command.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = alumno.Apellido });
						command.Parameters.Add(new SqlParameter("@FechaNacimiento", SqlDbType.Date) { Value = alumno.FechaNacimiento });
						command.Parameters.Add(new SqlParameter("@ProfesorId", SqlDbType.Int) { Value = alumno.ProfesorId });


						using (var reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								resultado = alumno;
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

		public bool DeleteAlumno(int id)
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
