using Microsoft.EntityFrameworkCore;
using SWOTAnalysis.Interfaces;
using SWOTAnalysis.Models;

namespace SWOTAnalysis.Services
{
    public class OppurtunityRepo : IRepo<int, Oppurtunity>
    {
        private readonly SWOTContext _context;
        private readonly ILogger<OppurtunityRepo> _logger;

        public OppurtunityRepo(SWOTContext context, ILogger<OppurtunityRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Oppurtunity?> Add(Oppurtunity item)
        {
            try
            {
                _context.Oppurtunities.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Oppurtunity?> Delete(int key)
        {
            try
            {
                var oppurtunity = await Get(key);
                if (oppurtunity != null)
                {
                    _context.Oppurtunities.Remove(oppurtunity);
                    await _context.SaveChangesAsync();
                    return oppurtunity;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Oppurtunity?> Get(int key)
        {
            try
            {
                var oppurtunity = await _context.Oppurtunities.FirstOrDefaultAsync(o=>o.OppurtunityId==key);
                return oppurtunity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Oppurtunity>?> GetAll()
        {
            try
            {
                var oppurtunities = await _context.Oppurtunities.ToListAsync();
                if (oppurtunities.Count > 0)
                    return oppurtunities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Oppurtunity?> Update(Oppurtunity item)
        {
            try
            {
                var oppurtunity = await Get(item.OppurtunityId);
                if (oppurtunity != null)
                {
                    oppurtunity.OppurtunityId = item.OppurtunityId;
                    oppurtunity.OppurtunityValue = item.OppurtunityValue;
                    oppurtunity.OppurtunityDescription = item.OppurtunityDescription;
                    await _context.SaveChangesAsync();
                    return oppurtunity;
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
