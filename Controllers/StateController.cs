using APIDemo.Data;
using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StateController : ControllerBase
	{
		private readonly StateRepository _stateRepository;
		public StateController(StateRepository stateRepository)
		{
			_stateRepository = stateRepository;
		}

		[HttpGet]
		#region Get All State
		public IActionResult GetAllStates()
		{
			var stateslist = _stateRepository.GetAllStates();
			return Ok(stateslist);

		}
		#endregion

		[HttpPost]
		#region Insert State
		public IActionResult InsertCountry(StateModel sm)
		{
			var inserted = _stateRepository.StateInsert(sm);
			if (inserted)
				return Ok(new { Message = "Record Inserted Successfully" });
			else
				return StatusCode(500, new { Message = "Record could not be inserted" });
		}
		#endregion

		[HttpPut("{StateID}")]
		#region Update State
		public IActionResult UpdateState(StateModel sm)
		{
			var updated = _stateRepository.StateUpdate(sm);
			if (updated)
				return Ok(new { Message = "Record Updated Successfully" });
			else
				return StatusCode(500, new { Message = "Record could not be updated" });

		}
		#endregion

		[HttpDelete("{StateID}")]
		#region Delete State
		public IActionResult DeleteCountry(int StateID, StateModel sm)
		{
			var deleted = _stateRepository.StateDelete(sm);
			if (deleted)
				return Ok(new { Message = "Record Deleted Successfully" });
			else
				return StatusCode(500, new { Message = "Record could not be deleted" });
		}
		#endregion



	}
}
