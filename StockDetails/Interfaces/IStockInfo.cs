using StockDetails.Models.DTOs;

namespace StockDetails.Interfaces
{
    public interface IStockInfo
    {
        Task<StockDTO> GetAllStockDetails(int companyID);
    }
}
