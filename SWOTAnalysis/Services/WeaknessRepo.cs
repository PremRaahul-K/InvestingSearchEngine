using Microsoft.EntityFrameworkCore;
using SWOTAnalysis.Interfaces;
using SWOTAnalysis.Models;

namespace SWOTAnalysis.Services
{
    public class WeaknessRepo:IRepo<int, Weakness>
    {
        private readonly SWOTContext _context;
        private readonly ILogger<WeaknessRepo> _logger;

        public WeaknessRepo(SWOTContext context, ILogger<WeaknessRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Weakness?> Add(Weakness item)
        {
            try
            {
                _context.Weaknesses.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Weakness?> Delete(int key)
        {
            try
            {
                var weakness = await Get(key);
                if (weakness != null)
                {
                    _context.Weaknesses.Remove(weakness);
                    await _context.SaveChangesAsync();
                    return weakness;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Weakness?> Get(int key)
        {
            try
            {
                var weakness = await _context.Weaknesses.FirstOrDefaultAsync(w=>w.WeaknessId==key);
                return weakness;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Weakness>?> GetAll()
        {
            try
            {
                var weaknesses = await _context.Weaknesses.ToListAsync();
                if (weaknesses.Count > 0)
                    return weaknesses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Weakness?> Update(Weakness item)
        {
            try
            {
                var weakness = await Get(item.WeaknessId);
                if (weakness != null)
                {
                    weakness.WeaknessId = item.WeaknessId;
                    weakness.WeaknessValue = item.WeaknessValue;
                    weakness.WeaknessDescription = item.WeaknessDescription;
                    await _context.SaveChangesAsync();
                    return weakness;
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
