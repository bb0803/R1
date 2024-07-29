using R1.Services.API.Models.Data;

namespace R1.Services.API.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<SessionLapTime> GetSessionLapTimeDetailsAsync(int id);

        Task<List<SessionLapTime>> GetSessionLapTimesAsync();
    }
}
