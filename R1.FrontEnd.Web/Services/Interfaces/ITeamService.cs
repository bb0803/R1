using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;
using R1.FrontEnd.Web.Models.Dto;

namespace R1.FrontEnd.Web.Services.Interfaces
{
    public interface ITeamService
    {
        Task<ResponseDto?> GetAvailableStaffAsync();
        Task<ResponseDto?> GetTeamStatusAsync();
        Task<ResponseDto?> SetupWorldAsync(SetupWorldDto swDto);
        Task<ResponseDto?> PostTransactionAsync(Transaction tran);
        Task<ResponseDto?> HireStaffAsync(AvailableStaffDto staff);
        Task<ResponseDto?> SackStaffAsync(int staffId);
        Task<ResponseDto?> ChangeCarSettingsAsync(Chassis car);
        Task<ResponseDto?> ChangeDriverSettingsAsync(Driver drv);
    }
}
