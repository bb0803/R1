using R1.Services.API.Models.Data;

namespace R1.Services.API.Repositories.Interfaces
{
    public interface ISessionRepository 
    {
        Task<List<SessionLapTime>> DoPracticeLapAsync();
        
        Task<List<SessionLapTime>> DoQualifyingLapAsync();
        
        Task<List<SessionLapTime>> DoRaceLapAsync();

        Task<List<RaceGrid>> CreateGridAsync();

        Task<int> PitAsync();

        Task<int> ChangeDriverSettingsAsync(Driver drv);

        Task<int> ChangeCarSettingAsync(Chassis car);

        Task<int> ChangeCarTyreAsync(int CarTyre);

        }
}
