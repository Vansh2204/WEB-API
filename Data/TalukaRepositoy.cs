using APIDemo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace APIDemo.Data
{
	public class TalukaRepositoy
	{
		private readonly IConfiguration _configuration;
		public TalukaRepositoy(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		#region GetAll Taluka
		public List<TalukaModel> GetAllTaluka()
		{
			var talukalist = new List<TalukaModel>();
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from LOC_Taluka";
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				talukalist.Add(new TalukaModel
				{
					TalukaID = Convert.ToInt32(reader["TalukaID"]),
					TalukaName = reader["TalukaName"].ToString(),
					DistrictID = Convert.ToInt32(reader["DistrictID"]),
					DistrictName = reader["DistrictName"].ToString(),
					UserID = Convert.ToInt32(reader["UserID"]),
					CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
					ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"])


				});
			}
			return talukalist;

		}
		#endregion

		#region Insert Taluka
		public bool InsertTaluka(TalukaModel tm)
		{
			bool IsInserted = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Taluka_Insert";
			cmd.Parameters.AddWithValue("TalukaName", tm.TalukaName);
			cmd.Parameters.AddWithValue("DistrictID", tm.DistrictID);
			cmd.Parameters.AddWithValue("DistrictName", tm.DistrictName);
			cmd.Parameters.AddWithValue("UserID", tm.UserID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsInserted = rowsaffected > 0;
			return IsInserted;


		}
		#endregion

		#region Update Taluka
		public bool UpdateTaluka(TalukaModel tm)
		{
			bool IsUpdated = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Taluka_Update";
			cmd.Parameters.AddWithValue("TalukaID", tm.TalukaID);
			cmd.Parameters.AddWithValue("TalukaName", tm.TalukaName);
			cmd.Parameters.AddWithValue("DistrictID", tm.DistrictID);
			cmd.Parameters.AddWithValue("DistrictName", tm.DistrictName);
			cmd.Parameters.AddWithValue("UserID", tm.UserID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsUpdated = rowsaffected > 0;
			return IsUpdated;


		}
		#endregion

		#region Delete Taluka
		public bool DeleteTaluka(TalukaModel tm)
		{
			bool IsDeleted = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Taluka_Delete";
			cmd.Parameters.AddWithValue("TalukaID", tm.TalukaID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsDeleted = rowsaffected > 0;
			return IsDeleted;
		}

		#endregion
	}
}
