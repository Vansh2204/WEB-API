using APIDemo.Models;
using System.Data;
using System.Data.SqlClient;

namespace APIDemo.Data
{
	public class DistrictRepository
	{
		private readonly IConfiguration _configuration;

		public DistrictRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		#region Get All Districts
		public List<DistrictModel> GetAllDistricts()
		{
			var districts = new List<DistrictModel>();
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from LOC_District";
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				districts.Add(new DistrictModel
				{
					DistrictID = Convert.ToInt32(reader["DistrictID"]),
					DistrictName = reader["DistrictName"].ToString(),
					StateID = Convert.ToInt32(reader["StateID"]),
					StateName = reader["StateName"].ToString(),
					UserID = Convert.ToInt32(reader["UserID"]),
				});

			}
			return districts;

		}
		#endregion

		#region Insert District
		public bool InsertDistrict(DistrictModel dm)
		{
			bool IsInserted = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_District_Insert";
			cmd.Parameters.AddWithValue("DistrictName", dm.DistrictName);
			cmd.Parameters.AddWithValue("StateID", dm.StateID);
			cmd.Parameters.AddWithValue("StateName",dm.StateName);
			cmd.Parameters.AddWithValue("UserID",dm.UserID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsInserted = rowsaffected > 0;
			return IsInserted;



		}
		#endregion

		#region Update District
		public bool UpdateDistrict(DistrictModel dm)
		{
			bool IsUpdated = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_District_Update";
			cmd.Parameters.AddWithValue("DistrictID", dm.DistrictID);
			cmd.Parameters.AddWithValue("DistrictName", dm.DistrictName);
			cmd.Parameters.AddWithValue("StateID", dm.StateID);
			cmd.Parameters.AddWithValue("StateName", dm.StateName);
			cmd.Parameters.AddWithValue("UserID", dm.UserID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsUpdated = rowsaffected > 0;
			return IsUpdated;



		}
		#endregion

		#region Delete District
		public bool DeleteDistrict(DistrictModel dm)
		{
			bool IsDeleted = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_District_Delete";
			cmd.Parameters.AddWithValue("DistrictID", dm.DistrictID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsDeleted = rowsaffected > 0;
			return IsDeleted;



		}
		#endregion
	}
}