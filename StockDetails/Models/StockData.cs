using System.ComponentModel.DataAnnotations;

namespace StockDetails.Models
{
    public class StockData
    {
        [Key]
        public int StockID { get; set; }
        public int CompanyID { get; set; }
        public double TodayHigh { get; set; }
        public double TodayLow { get; set; }
        public double YearHigh { get; set; }
        public double YearLow { get; set; }
        public DateTime  Date { get; set; }
        public ICollection<DailyStock> DailyStocks { get; set; }

    }
}
