using System.ComponentModel.DataAnnotations;

namespace SWOTAnalysis.Models
{
    public class Threat
    {
        [Key]
        public int ThreatId { get; set; }
        public int ThreatValue { get; set; }
        public string? ThreatDescription { get; set; }
    }
}
