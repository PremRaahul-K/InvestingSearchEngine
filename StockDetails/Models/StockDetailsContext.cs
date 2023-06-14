using Microsoft.EntityFrameworkCore;

namespace StockDetails.Models
{
    public class StockDetailsContext:DbContext
    {
        public StockDetailsContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<StockData> StockDetails { get; set; }
        public DbSet<DailyStock> DailyStocks{ get; set; }
    }
}
