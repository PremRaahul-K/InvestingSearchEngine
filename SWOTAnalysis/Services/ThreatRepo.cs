using Microsoft.EntityFrameworkCore;
using SWOTAnalysis.Interfaces;
using SWOTAnalysis.Models;
using System.Threading;

namespace SWOTAnalysis.Services
{
    public class ThreatRepo:IRepo<int, Threat>
    {
        private readonly SWOTContext _context;
        private readonly ILogger<ThreatRepo> _logger;

        public ThreatRepo(SWOTContext context, ILogger<ThreatRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Threat?> Add(Threat item)
        {
            try
            {
                _context.Threats.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Threat?> Delete(int key)
        {
            try
            {
                var threat = await Get(key);
                if (threat != null)
                {
                    _context.Threats.Remove(threat);
                    await _context.SaveChangesAsync();
                    return threat;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Threat?> Get(int key)
        {
            try
            {
                var threat = await _context.Threats.FirstOrDefaultAsync(t =>t.ThreatId== key);
                return threat;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Threat>?> GetAll()
        {
            try
            {
                var threats = await _context.Threats.ToListAsync();
                if (threats.Count > 0)
                    return threats;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Threat?> Update(Threat item)
        {
            try
            {
                var threat = await Get(item.ThreatId);
                if (threat != null)
                {
                    threat.ThreatId = item.ThreatId;
                    threat.ThreatValue = item.ThreatValue;
                    threat.ThreatDescription = item.ThreatDescription;
                    await _context.SaveChangesAsync();
                    return threat;
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
