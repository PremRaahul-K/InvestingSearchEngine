using System.ComponentModel.DataAnnotations;

namespace SWOTAnalysis.Models
{
    public class Strength
    {
        [Key]
        public int StrengthId { get; set; }
        public int StrengthValue { get; set; }
        public string? StrengthDescription { get; set; }
    }
}
