using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;

namespace R1.FrontEnd.Web.Services.Interfaces
{
    public interface ISessionService
    {
        Task<ResponseDto?> DoPracticeLapAsync();
        Task<ResponseDto?> DoQualifyingLapAsync();
        Task<ResponseDto?> DoRaceLapAsync();
        Task<ResponseDto?> CreateGridAsync();

        Task<ResponseDto?> ChangeCarSettingsAsync(Chassis car);
        Task<ResponseDto?> ChangeDriverSettingsAsync(Driver drv);
        Task<ResponseDto?> ChangeCarTyreAsync(int id);
        Task<ResponseDto?> PitAsync(int id);
    }
}
