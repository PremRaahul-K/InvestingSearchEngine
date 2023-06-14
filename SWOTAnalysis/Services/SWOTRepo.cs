using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SWOTAnalysis.Interfaces;
using SWOTAnalysis.Models;

namespace SWOTAnalysis.Services
{
    public class SWOTRepo:IRepo<int,SWOT>
    {
        private readonly SWOTContext _context;
        private readonly ILogger<SWOTRepo> _logger;

        public SWOTRepo(SWOTContext context, ILogger<SWOTRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<SWOT?> Add(SWOT item)
        {
            try
            {
                _context.SWOT.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<SWOT?> Delete(int key)
        {
            try
            {
                var swot = await Get(key);
                if (swot != null)
                {
                    _context.Strengths.RemoveRange(swot.strength);
                    _context.Weaknesses.RemoveRange(swot.weakness);
                    _context.Oppurtunities.RemoveRange(swot.oppurtunity);
                    _context.Threats.RemoveRange(swot.threat);
                    _context.SWOT.Remove(swot);
                    await _context.SaveChangesAsync();
                    return swot;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<SWOT?> Get(int key)
        {
            try
            {
                var swot = await _context.SWOT.Include(swot => swot.strength).Include(swot => swot.weakness).Include(swot => swot.oppurtunity).Include(swot => swot.threat).FirstOrDefaultAsync(s => s.SwotId == key);
                return swot;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<SWOT>?> GetAll()
        {
            try
            {
                var swot = await _context.SWOT.Include(swot => swot.strength).Include(swot => swot.weakness).Include(swot => swot.oppurtunity).Include(swot => swot.threat).ToListAsync();
                if (swot.Count > 0)
                    return swot;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<SWOT?> Update(SWOT item)
        {
            try
            {
                var swot = await Get(item.SwotId);
                if (swot != null)
                {
                    swot.SwotId = item.SwotId;
                    swot.CompanyID = item.CompanyID;
                    swot.StrengthId = item.StrengthId;
                    swot.WeaknessId = item.WeaknessId;
                    swot.OppurtunityId = item.OppurtunityId;
                    swot.ThreatId = item.ThreatId;
                    swot.strength = item.strength;
                    swot.weakness = item.weakness;
                    swot.oppurtunity = item.oppurtunity;
                    swot.threat = item.threat;
                    await _context.SaveChangesAsync();
                    return swot;
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
