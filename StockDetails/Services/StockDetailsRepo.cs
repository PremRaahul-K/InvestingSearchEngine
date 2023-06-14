using Microsoft.EntityFrameworkCore;
using StockDetails.Interfaces;
using StockDetails.Models;

namespace StockDetails.Services
{
    public class StockDetailsRepo : IRepo<int, StockData>
    {
        private readonly StockDetailsContext _context;
        private readonly ILogger<StockDetailsRepo> _logger;

        public StockDetailsRepo(StockDetailsContext context, ILogger<StockDetailsRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<StockData?> Add(StockData item)
        {
            try
            {
                _context.StockDetails.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<StockData?> Delete(int key)
        {
            try
            {
                var stockInfo = await Get(key);
                if (stockInfo != null)
                {
                    _context.StockDetails.Remove(stockInfo);
                    await _context.SaveChangesAsync();
                    return stockInfo;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<StockData?> Get(int key)
        {
            try
            {
                var stockInfo = _context.StockDetails.Include(s=>s.DailyStocks).FirstOrDefault(s=>s.StockID==key);
                return stockInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<StockData>?> GetAll()
        {
            try
            {
                var stockInfos = await _context.StockDetails.Include(s=>s.DailyStocks).ToListAsync();
                if (stockInfos.Count > 0)
                    return stockInfos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<StockData?> Update(StockData item)
        {
            try
            {
                var stockinfo = await Get(item.StockID);
                if (stockinfo != null)
                {
                    stockinfo.StockID = item.StockID;
                    stockinfo.YearLow = item.YearLow;
                    stockinfo.YearHigh = item.YearHigh;
                    stockinfo.TodayHigh = item.TodayHigh;
                    stockinfo.TodayLow = item.TodayLow;
                    stockinfo.Date = item.Date;
                    stockinfo.CompanyID = item.CompanyID;
                    stockinfo.DailyStocks = item.DailyStocks;
                    await _context.SaveChangesAsync();
                    return stockinfo;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}
