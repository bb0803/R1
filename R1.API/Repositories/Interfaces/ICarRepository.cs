using R1.Services.API.Models.Data;
using R1.Services.API.Models.Dto;

namespace R1.Services.API.Repositories.Interfaces
{
    public interface ICarRepository 
    {
        Task<Engine> GetCurrentEngineAsync();

        Task<Chassis> GetCurrentChassisAsync();

        Task<List<AvailableEngineDto>> GetAvailableEnginesAsync();

        Task<List<AvailableChassisDto>> GetAvailableChassisAsync();

        Task<int> PurchaseEngineAsync(int EngineId);
        Task<int> PurchaseChassisAsync(int ChassisId);

        Task<string> GetPartStatusAsync();

        Task<string> GetAvailablePartsAsync();
    }
}
