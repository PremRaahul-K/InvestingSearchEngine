using SWOTAnalysis.Models.DTOs;

namespace SWOTAnalysis.Interfaces
{
    public interface ISWOTDetails
    {
        Task<SwotDTO> GetSWOTDetailsByCompanyID(int companyID);
    }
}
