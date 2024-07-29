using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;

namespace R1.FrontEnd.Web.Services.Interfaces
{
    public interface ICarService
    {
        Task<ResponseDto?> GetCurrentEngineAsync();
        Task<ResponseDto?> GetCurrentChassisAsync();
        Task<ResponseDto?> GetAvailableEnginesAsync();
        Task<ResponseDto?> GetAvailableChassisAsync();
        Task<ResponseDto?> PurchaseEngineAsync(int engineId);
        Task<ResponseDto?> PurchaseChassisAsync(int chassisId); 
        Task<ResponseDto?> GetPartStatusAsync();
        Task<ResponseDto?> GetAvailablePartsAsync();
    }
}
