using APIDemo.Data;
using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TalukaController : ControllerBase
	{
		private readonly TalukaRepositoy _talukaRepositoy;
		public TalukaController(TalukaRepositoy talukaRepositoy)
		{
			_talukaRepositoy = talukaRepositoy;
		}

		[HttpGet]
		public IActionResult GetAllTaluka() {
			var taluka = _talukaRepositoy.GetAllTaluka();
			return Ok(taluka);
		}

		[HttpPost]
		public IActionResult InsertTaluka(TalukaModel tm) { 
			var inserted = _talukaRepositoy.InsertTaluka(tm);
			if (inserted)
				return Ok(new { Message = "Taluka Details Inserted" });
			else
				return StatusCode(500, new {Message = "Record cannot be Inserted"});
		}

		[HttpPut("{TalukaID}")]
		public IActionResult UpdateTaluka(int TalukaID,TalukaModel tm)
		{
			var isupdated = _talukaRepositoy.UpdateTaluka(tm);
			if (isupdated)
				return Ok(new { Message = "Details Updated Successfully" });
			else
				return NotFound(new { Message = "Details not found to update" });

		}
		[HttpDelete("{TalukaID}")]
		public IActionResult DeleteTaluka(int TalukaID,TalukaModel tm) {
			var isupdated = _talukaRepositoy.DeleteTaluka(tm);
			if (isupdated)
				return Ok(new { Message = "Details Deleted Successfully" });
			else
				return StatusCode(500, new { Message = "Deletion Failed" });
		}

	}
}
