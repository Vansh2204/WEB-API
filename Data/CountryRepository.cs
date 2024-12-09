using APIDemo.Models;
using System.Data;
using System.Data.SqlClient;


namespace APIDemo.Data
{
	public class CountryRepository
	{
		private readonly IConfiguration _configuration;
		public CountryRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		#region Get All Countries
		public List<CountryModel> GetAllCountries()
		{
			var countryList = new List<CountryModel>();
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from LOC_Country";
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read()) {
				countryList.Add(new CountryModel {
					CountryID = Convert.ToInt32(reader["CountryID"]),
					CountryName = reader["CountryName"].ToString(),
					UserID = Convert.ToInt32(reader["UserID"]),
					CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
					ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),



				});
			
			}
			return countryList;
		}
		#endregion

		#region Insert Country
		public bool CountryInsert(CountryModel cm)
		{
			bool IsInserted = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Country_Insert";
			cmd.Parameters.AddWithValue("CountryName",cm.CountryName);
			cmd.Parameters.AddWithValue("UserID", cm.UserID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsInserted = rowsaffected > 0;
			return IsInserted;



		}
		#endregion

		#region Update Country
		public bool CountryUpdate(CountryModel cm)
		{
			bool IsUpdated = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Country_Update";
			cmd.Parameters.AddWithValue("CountryID", cm.CountryID);
			cmd.Parameters.AddWithValue("CountryName", cm.CountryName);
			cmd.Parameters.AddWithValue("UserID", cm.UserID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsUpdated = rowsaffected > 0;
			return IsUpdated;



		}

		#endregion

		#region Delete Country
		public bool CountryDelete(CountryModel cm) {
			bool IsDeleted = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Country_Delete";
			cmd.Parameters.AddWithValue("CountryID", cm.CountryID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsDeleted = rowsaffected > 0;
			return IsDeleted;

		}
		#endregion
	}
}
