using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockDetails.Interfaces;
using StockDetails.Models;
using StockDetails.Models.DTOs;

namespace StockDetails.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockDetailsController : ControllerBase
    {
        private readonly IRepo<int, StockData> _repo;
        private readonly IStockInfo _stockInfo;

        public StockDetailsController(IRepo<int, StockData> repo,IStockInfo stockInfo)
        {
            _repo = repo;
            _stockInfo = stockInfo;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<ICollection<StockData>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<StockData>>> GetAll()
        {
            var stockInfo = await _repo.GetAll();
            if (stockInfo == null)
            {
                return NotFound("No Details are available at the moment");
            }
            return Ok(stockInfo);
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<StockDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StockDTO>> GetStockDetails(int companyID)
        {
            var stockDTO = await _stockInfo.GetAllStockDetails(companyID);
            if (stockDTO == null)
            {
                return NotFound("No Details are available at the moment");
            }
            return Ok(stockDTO);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<StockData>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<StockData>>> Add(StockData stockInfo)
        {
            var result = await _repo.Add(stockInfo);
            if (result == null)
            {
                return NotFound("unable to add the stock details");
            }
            return Created("Home", result);
        }
        [HttpPut]
        [ProducesResponseType(typeof(ActionResult<StockData>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StockData>> Update(StockData stockInfo)
        {
            var result = await _repo.Update(stockInfo);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to update stock details");
        }
        [HttpDelete]
        [ProducesResponseType(typeof(ActionResult<StockData>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StockData>> Delete(int id)
        {
            var result = await _repo.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to Delete stock details");
        }
    }
}
