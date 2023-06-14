using System.ComponentModel.DataAnnotations;

namespace SWOTAnalysis.Models
{
    public class Weakness
    {
        [Key]
        public int WeaknessId { get; set; }
        public int WeaknessValue { get; set; }
        public string? WeaknessDescription { get; set; }
    }
}
