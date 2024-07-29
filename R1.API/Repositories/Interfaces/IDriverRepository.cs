using R1.Services.API.Models.Data;

namespace R1.Services.API.Repositories.Interfaces
{
    public interface IDriverRepository 
    {
        Task<List<Driver>> GetTeamDriversAsync();

        Task<List<Driver>> GetAvailableDriversAsync();

        Task<int> ChangeDriverSettingsAsync(Driver drv);

        Task<int> HireDriverAsync(int DriverId);

        Task<int> SackDriverAsync(int DriverId);
    }
}
