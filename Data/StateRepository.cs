using APIDemo.Models;
using System.Data;
using System.Data.SqlClient;

namespace APIDemo.Data
{
	public class StateRepository
	{
		private readonly IConfiguration _configuration;
		public StateRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		#region Get All Countries
		public List<StateModel> GetAllStates()
		{
			var stateslist = new List<StateModel>();
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from LOC_State";
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				stateslist.Add(new StateModel
				{
					StateID = Convert.ToInt32(reader["StateID"]),
					StateName = reader["StateName"].ToString(),
					CountryID = Convert.ToInt32(reader["CountryID"]),
					UserID = Convert.ToInt32(reader["UserID"]),
					CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
					ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),



				});

			}
			return stateslist;
		}
		#endregion

		#region Insert State
		public bool StateInsert(StateModel sm)
		{
			bool IsInserted = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_State_Insert";
			cmd.Parameters.AddWithValue("StateName", sm.StateName);
			cmd.Parameters.AddWithValue("CountryID", sm.CountryID);
			cmd.Parameters.AddWithValue("UserID", sm.UserID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsInserted = rowsaffected > 0;
			return IsInserted;



		}
		#endregion

		#region Update State
		public bool StateUpdate(StateModel sm)
		{
			bool IsUpdated = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_State_Update";
			cmd.Parameters.AddWithValue("StateID", sm.StateID);
			cmd.Parameters.AddWithValue("StateName", sm.StateName);
			cmd.Parameters.AddWithValue("CountryID", sm.CountryID);
			cmd.Parameters.AddWithValue("UserID", sm.UserID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsUpdated = rowsaffected > 0;
			return IsUpdated;



		}

		#endregion

		#region Delete State
		public bool StateDelete(StateModel sm)
		{
			bool IsDeleted = false;
			string str = _configuration.GetConnectionString("myConnectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_State_Delete";
			cmd.Parameters.AddWithValue("StateID", sm.StateID);
			int rowsaffected = cmd.ExecuteNonQuery();
			IsDeleted = rowsaffected > 0;
			return IsDeleted;

		}
		#endregion

	}
}
