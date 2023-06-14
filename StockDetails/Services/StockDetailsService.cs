using StockDetails.Interfaces;
using StockDetails.Models;
using StockDetails.Models.DTOs;

namespace StockDetails.Services
{
    public class StockDetailsService : IStockInfo
    {
        private readonly IRepo<int, StockData> _repo;
        private readonly IRepo<int, DailyStock> _dailyStockRepo;

        public StockDetailsService(IRepo<int, StockData> repo, IRepo<int, DailyStock> dailyStockRepo)
        {
            _repo = repo;
            _dailyStockRepo = dailyStockRepo;
        }
        public async Task<StockDTO> GetAllStockDetails(int companyID)
        {
            
            var stockDTO = new StockDTO();
            DateTime currentDate = DateTime.Today;
            var stockId = (await _repo.GetAll()).FirstOrDefault(s=>s.CompanyID==companyID).StockID;
            var stockDetails = (await _dailyStockRepo.GetAll()).Where(s => s.StockDataStockID == stockId);
            stockDTO.CompanyID = companyID;
            stockDTO.YearHigh = stockDetails.OrderByDescending(s => s.Date).Take(365).Sum(s => s.High) / 365;
            stockDTO.YearLow = stockDetails.OrderByDescending(s => s.Date).Take(365).Sum(s => s.Low) / 365;
            stockDTO.TodayHigh = stockDetails.Max(s => s.High);
            stockDTO.TodayLow = stockDetails.Min(s => s.Low);
            return stockDTO;
        }
    }
}
