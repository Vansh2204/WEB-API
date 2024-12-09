using APIDemo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace APIDemo.Data
{
	public class CityRepository
	{
		#region Configurations
		private readonly IConfiguration _configuration;

		public CityRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		#endregion

		#region GetAll Cities
		public List<CityModel> GetAllCities()
		{
			var cities = new List<CityModel>();
			SqlConnection con = new SqlConnection(_configuration.GetConnectionString("myConnectionString"));
			con.Open();
				SqlCommand cmd = new SqlCommand("select * from LOC_City", con)
				{
					
					CommandType = CommandType.Text
				};
				Console.WriteLine(con);
		
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					cities.Add(new CityModel
					{
						CityID = Convert.ToInt32(reader["CityID"]),
						CityName = reader["CityName"].ToString(),
						TalukaID = Convert.ToInt32(reader["TalukaID"]),
						TalukaName = reader["TalukaName"].ToString(),
						UserID = Convert.ToInt32(reader["UserID"]),
						CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
						ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"])

					});
				
			}
			return cities;
		}
		#endregion

		#region Insert City
		public bool InsertCity(CityModel cm)
		{
			bool inserted = false;
			string str = this._configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_Insert";
			cmd.Parameters.AddWithValue("CityName", cm.CityName);
			cmd.Parameters.AddWithValue("TalukaID", cm.TalukaID);
			cmd.Parameters.AddWithValue("TalukaName", cm.CityName);
			cmd.Parameters.AddWithValue("UserID", cm.UserID);
			int rowsAffected = cmd.ExecuteNonQuery();
			inserted = rowsAffected > 0;
			return inserted;

		}
		#endregion

		#region Delete City
		public bool DeleteCity(int CityID)
		{
			bool isDeleted = false;
			string connectionString = _configuration.GetConnectionString("myConnectionString");
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "PR_City_Delete";
			command.Parameters.AddWithValue("CityID", CityID);
			int rowsAffected = command.ExecuteNonQuery();
			isDeleted = rowsAffected > 0;
			return isDeleted;
		}
		#endregion

		#region Update City
		public bool UpdateCity(CityModel cm)
		{
			bool isUpdate = false;
			string connectionString = _configuration.GetConnectionString("myConnectionString");
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "PR_City_Update";
			command.Parameters.AddWithValue("CityID", cm.CityID);
			command.Parameters.AddWithValue("CityName", cm.CityName);
			command.Parameters.AddWithValue("TalukaName", cm.CityName);
			command.Parameters.AddWithValue("TalukaID", cm.TalukaID);
			command.Parameters.AddWithValue("UserID", cm.UserID);
			int rowsAffected = command.ExecuteNonQuery();
			isUpdate = rowsAffected > 0;
			return isUpdate;
		}
		#endregion


	}
}
