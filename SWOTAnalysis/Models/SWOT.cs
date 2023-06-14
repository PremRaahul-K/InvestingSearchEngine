using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWOTAnalysis.Models
{
    public class SWOT
    {
        [Key]
        public int SwotId { get; set; }
        public int CompanyID { get; set; }
        [ForeignKey("strength")]
        public int StrengthId { get; set; }
        public Strength strength { get; set; }
        [ForeignKey("weakness")]
        public int WeaknessId { get; set; }
        public Weakness weakness { get; set; }
        [ForeignKey("threat")]
        public int ThreatId { get; set; }
        public Threat threat { get; set; }
        [ForeignKey("oppurtunity")]
        public int OppurtunityId { get; set; }
        public Oppurtunity oppurtunity { get; set; }
        public DateTime Date { get; set; }
    }
}
