using R1.Services.API.Models.Data;
using R1.Services.API.Models.Dto;
using R1.Services.API.Models.User;

namespace R1.Services.API.Repositories.Interfaces
{
    public interface ITeamRepository 
    {
        Task<List<StaffDto>> GetAvailableStaffAsync();

        Task<Team> GetTeamStatusAsync();
        
        Task<UserSetting> SetupWorldAsync(string TeamName, int ClassId);

        Task<int> PostTransactionAsync(Transaction tran);

        Task<int> SackStaffAsync(int staffId);

        Task<int> HireStaffAsync(AvailableStaffDto staff);

        Task<DriverSetting> ChangeDriverSettingsAsync(int DriverId);

        Task<int> ChangeCarSettingsAsync();

    }
}
