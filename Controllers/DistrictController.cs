using APIDemo.Data;
using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DistrictController : ControllerBase
	{
		private readonly DistrictRepository districtRepository;
		public DistrictController(DistrictRepository districtRepository)
		{
			this.districtRepository = districtRepository;
		}

		[HttpGet]
		#region Get All Districts
		public ActionResult GetAllDistricts() { 
			var districts = districtRepository.GetAllDistricts();
			return Ok(districts);
		}
		#endregion

		[HttpPost]
		#region Insert District
		public IActionResult InsertDistrict(DistrictModel dm)
		{
			var inserted = districtRepository.InsertDistrict(dm);
			if (inserted)
				return Ok(new { Message = "Record Inseted Successfully" });
			else
				return StatusCode(500, new { Message = "Failed to Insert" });
		}
		#endregion

		[HttpPut("{DistrictID}")]
		#region Update District
		public IActionResult UpdateDistrict(int DistrictID , DistrictModel dm) { 
			var isupdated = districtRepository.UpdateDistrict(dm);
			if (isupdated)
				return Ok(new { Message = "Record updated Successfully" });
			else
				return NotFound(new {Message = "Record not found to Update" });
		}
		#endregion

		[HttpDelete("{DistrictID}")]
		#region Delete District
		public IActionResult DeleteDistrict(int DistrictID, DistrictModel dm)
		{
			var isupdated = districtRepository.DeleteDistrict(dm);
			if (isupdated)
				return Ok(new { Message = "Record Deleted Successfully" });
			else
				return NotFound(new { Message = "Record not found to Delete" });
		}
		#endregion

	}
}
