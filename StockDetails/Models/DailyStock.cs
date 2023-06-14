using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace StockDetails.Models
{
    public class DailyStock
    {
        [Key]
        public int Id { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public DateTime Date { get; set; }
        public int StockDataStockID { get; set; }
    }
}
