using APIDemo.Data;
using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace APIDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		#region Configurations
		private readonly CityRepository _cityRepository;

		public CityController(CityRepository cityrepository)
		{
			_cityRepository = cityrepository;

		}
		#endregion

		[HttpGet]
		#region GetALL
		public IActionResult GetAllCities()
		{
			var citylist = _cityRepository.GetAllCities();
			return Ok(citylist);
		}
		#endregion

		[HttpPost]
		#region Insert
		public IActionResult InsertCity(CityModel cm)
		{

			var isInserted = _cityRepository.InsertCity(cm);
			if (isInserted)
				return Ok(new { Message = "City inserted successfully." });
			else
				return StatusCode(500, new { Message = "City could not be inserted." });
		}
		#endregion

		[HttpPut("{CityID}")]
		#region Update City
		public IActionResult UpdateCity(int CityID, CityModel cm)
		{
			if (cm == null || CityID != cm.CityID)
				return BadRequest(new { Message = "Invalid city data or ID mismatch." });

			var isUpdated = _cityRepository.UpdateCity(cm);
			if (isUpdated)
				return Ok(new { Message = "City updated successfully." });
			else
				return NotFound(new { Message = "City not found or could not be updated." });
		}
		#endregion

		[HttpDelete("{CityID}")]
		#region Delete
		public IActionResult DeleteCity(int CityID)
		{
			var isDeleted = _cityRepository.DeleteCity(CityID);
			if (isDeleted)
				return Ok(new { Message = "City deleted successfully." });
			else
				return NotFound(new { Message = "City could not be deleted." });
		}
		#endregion

		
	}
}
