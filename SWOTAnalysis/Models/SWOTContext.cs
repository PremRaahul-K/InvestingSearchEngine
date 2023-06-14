using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SWOTAnalysis.Models
{
    public class SWOTContext:DbContext
    {
        public SWOTContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<Oppurtunity> Oppurtunities { get; set; }
        public DbSet<Strength> Strengths { get; set; }
        public DbSet<Weakness> Weaknesses { get; set; }
        public DbSet<SWOT> SWOT { get; set; }

    }
}
