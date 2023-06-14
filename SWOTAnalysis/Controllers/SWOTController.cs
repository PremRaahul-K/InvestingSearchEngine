using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWOTAnalysis.Interfaces;
using SWOTAnalysis.Models;
using SWOTAnalysis.Models.DTOs;
using System.Data;

namespace SWOTAnalysis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SWOTController : ControllerBase
    {
        private readonly IRepo<int, SWOT> _repo;
        private readonly ISWOTDetails _swotDetails;

        public SWOTController(IRepo<int,SWOT> repo,ISWOTDetails swotDetails)
        {
            _repo = repo;
            _swotDetails = swotDetails;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<ICollection<SWOT>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<SWOT>>> GetAllSWOTDetails()
        {
            var swot = await _repo.GetAll();
            if (swot == null)
            {
                return NotFound("No Details are available at the moment");
            }
            return Ok(swot);
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<SwotDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SwotDTO>> GetSwotByCompanyID(int companyId)
        {
            var swot = await _swotDetails.GetSWOTDetailsByCompanyID(companyId);
            if (swot == null)
            {
                return NotFound("No Details are available at the moment");
            }
            return Ok(swot);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<SWOT>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<SWOT>>> AddSwotDeatails(SWOT swot)
        {
            var result = await _repo.Add(swot);
            if (result == null)
            {
                return NotFound("unable to add the swot details");
            }
            return Created("Home",result);
        }
        [HttpPut]
        [ProducesResponseType(typeof(ActionResult<SWOT>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SWOT>> UpdateSWOTDetails(SWOT swot)
        {
            var result = await _repo.Update(swot);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to update swot details");
        }
        [HttpDelete]
        [ProducesResponseType(typeof(ActionResult<SWOT>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SWOT>> DeleteSWOTDetails(int id)
        {
            var result = await _repo.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to Delete swot details");
        }
    }
}
