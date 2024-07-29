using R1.FrontEnd.WA.Models.API;
using R1.FrontEnd.WA.Models.Data;

namespace R1.FrontEnd.WA.Services.Interfaces
{
    public interface ISessionLapTimeService
    {
        Task<ResponseDto?> GetSessionLapTimeAsync(int id);
        Task<ResponseDto?> GetAllSessionLapTimesAsync();
        //Task<VirtualizeResponse<List<SessionLapTime>>> GetVirtualSessionLapTimesAsync(QueryParameters param);
        Task<ResponseDto?> CreateSessionLapTimeAsync(SessionLapTime sessionLapTimeDto);
        Task<ResponseDto?> UpdateSessionLapTimeAsync(SessionLapTime sessionLapTimeDto);
        Task<ResponseDto?> DeleteSessionLapTimeAsync(int id);
    }
}
