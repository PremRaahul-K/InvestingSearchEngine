using Microsoft.EntityFrameworkCore;
using StockDetails.Interfaces;
using StockDetails.Models;

namespace StockDetails.Services
{
    public class DailyStockRepo:IRepo<int,DailyStock>
    {
        private readonly StockDetailsContext _context;
        private readonly ILogger<DailyStockRepo> _logger;

        public DailyStockRepo(StockDetailsContext context, ILogger<DailyStockRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<DailyStock?> Add(DailyStock item)
        {
            try
            {
                _context.DailyStocks.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<DailyStock?> Delete(int key)
        {
            try
            {
                var dailyStock = await Get(key);
                if (dailyStock != null)
                {
                    _context.DailyStocks.Remove(dailyStock);
                    await _context.SaveChangesAsync();
                    return dailyStock;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<DailyStock?> Get(int key)
        {
            try
            {
                var dailyStock = _context.DailyStocks.FirstOrDefault(d=>d.Id == key);
                return dailyStock;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<DailyStock>?> GetAll()
        {
            try
            {
                var dailyStocks = await _context.DailyStocks.ToListAsync();
                if (dailyStocks.Count > 0)
                    return dailyStocks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<DailyStock?> Update(DailyStock item)
        {
            try
            {
                var dailyStock = await Get(item.Id);
                if (dailyStock != null)
                {
                    dailyStock.Id = item.Id;
                    dailyStock.High = item.High;
                    dailyStock.Low = item.Low;
                    dailyStock.Date = item.Date;
                    await _context.SaveChangesAsync();
                    return dailyStock;
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
