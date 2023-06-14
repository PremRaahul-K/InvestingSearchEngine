using Microsoft.EntityFrameworkCore;
using SWOTAnalysis.Interfaces;
using SWOTAnalysis.Models;

namespace SWOTAnalysis.Services
{
    public class StrengthRepo:IRepo<int,Strength>
    {
        private readonly SWOTContext _context;
        private readonly ILogger<StrengthRepo> _logger;

        public StrengthRepo(SWOTContext context, ILogger<StrengthRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Strength?> Add(Strength item)
        {
            try
            {
                _context.Strengths.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Strength?> Delete(int key)
        {
            try
            {
                var strength = await Get(key);
                if (strength != null)
                {
                    _context.Strengths.Remove(strength);
                    await _context.SaveChangesAsync();
                    return strength;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Strength?> Get(int key)
        {
            try
            {
                var strength = await _context.Strengths.FirstOrDefaultAsync(s=>s.StrengthId==key);
                return strength;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Strength>?> GetAll()
        {
            try
            {
                var strengths = await _context.Strengths.ToListAsync();
                if (strengths.Count > 0)
                    return strengths;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Strength?> Update(Strength item)
        {
            try
            {
                var strength = await Get(item.StrengthId);
                if (strength != null)
                {
                    strength.StrengthId = item.StrengthId;
                    strength.StrengthValue = item.StrengthValue;
                    strength.StrengthDescription = item.StrengthDescription;
                    await _context.SaveChangesAsync();
                    return strength;
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
