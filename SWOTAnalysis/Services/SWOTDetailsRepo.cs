using SWOTAnalysis.Interfaces;
using SWOTAnalysis.Models;
using SWOTAnalysis.Models.DTOs;
using System.Diagnostics;

namespace SWOTAnalysis.Services
{
    public class SWOTDetailsRepo : ISWOTDetails
    {
        private readonly IRepo<int, SWOT> _repo;

        public SWOTDetailsRepo(IRepo<int,SWOT> repo)
        {
            _repo = repo;
        }
        public async Task<SwotDTO> GetSWOTDetailsByCompanyID(int companyID)
        {
            try
            {
                var swotDetails = (await _repo.GetAll()).ToList().FirstOrDefault(s => s.CompanyID == companyID);
                var swotDTO = new SwotDTO();
                if (swotDetails != null)
                {
                    swotDTO.CompanyID = swotDetails.CompanyID;
                    swotDTO.StrengthValue = swotDetails.strength.StrengthValue;
                    swotDTO.StrengthDescription = swotDetails.strength.StrengthDescription;
                    swotDTO.WeaknessValue = swotDetails.weakness.WeaknessValue;
                    swotDTO.WeaknessDescription = swotDetails.weakness.WeaknessDescription;
                    swotDTO.ThreatValue = swotDetails.threat.ThreatValue;
                    swotDTO.ThreatDescription = swotDetails.threat.ThreatDescription;
                    swotDTO.OppurtunityValue = swotDetails.oppurtunity.OppurtunityValue;
                    swotDTO.OppurtunityDescription = swotDetails.oppurtunity.OppurtunityDescription;
                    return swotDTO;
                }
            }
            catch (ArgumentNullException ane)
            {
                Debug.WriteLine(ane.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
