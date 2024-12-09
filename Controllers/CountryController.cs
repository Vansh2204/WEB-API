using APIDemo.Data;
using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : ControllerBase
	{
		private readonly CountryRepository _countryRepository;
		public CountryController(CountryRepository countryRepository) { 
			_countryRepository = countryRepository;
		}

		[HttpGet]
		#region Get All Country
		public IActionResult GetAllCountries() { 
			var countrylist = _countryRepository.GetAllCountries();
			return Ok(countrylist);

		}
		#endregion

		[HttpPost]
		#region Insert Country
		public IActionResult InsertCountry(CountryModel cm)
		{
			var inserted = _countryRepository.CountryInsert(cm);
			if (inserted)
				return Ok(new { Message = "Record Inserted Successfully" });
			else
				return StatusCode(500, new { Message = "Record could not be inserted" });
		}
		#endregion

		[HttpPut("{CountryID}")]
		#region Update Country
		public IActionResult UpdateCountry(CountryModel cm) { 
			var updated = _countryRepository.CountryUpdate(cm);
			if (updated)
				return Ok(new { Message = "Record Updated Successfully" });
			else
				return StatusCode(500, new { Message = "Record could not be updated" });

		}
		#endregion

		[HttpDelete("{CountryID}")]
		#region Delete Country
		public IActionResult DeleteCountry(int CountryID,CountryModel cm) {
			var deleted = _countryRepository.CountryDelete(cm);
			if (deleted)
				return Ok(new { Message = "Record Deleted Successfully" });
			else
				return StatusCode(500, new { Message = "Record could not be deleted" });
		}
		#endregion

	}
}
