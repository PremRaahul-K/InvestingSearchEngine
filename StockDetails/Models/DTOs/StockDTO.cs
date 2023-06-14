namespace StockDetails.Models.DTOs
{
    public class StockDTO
    {
        public int CompanyID { get; set; }
        public double TodayHigh { get; set; }
        public double TodayLow { get; set; }
        public double YearHigh { get; set; }
        public double YearLow { get; set; }
        public DateTime Date { get; set; }
    }
}
