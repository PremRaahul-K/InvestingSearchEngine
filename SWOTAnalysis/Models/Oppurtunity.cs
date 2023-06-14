using System.ComponentModel.DataAnnotations;

namespace SWOTAnalysis.Models
{
    public class Oppurtunity
    {
        [Key]
        public int OppurtunityId { get; set; }
        public int OppurtunityValue { get; set; }
        public string? OppurtunityDescription { get; set; }
    }
}
