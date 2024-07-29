using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;

namespace R1.FrontEnd.Web.Services.Interfaces
{
    public interface IDriverService
    {
        Task<ResponseDto?> GetTeamDriversAsync();
        Task<ResponseDto?> GetAvailableDriversAsync();
        Task<ResponseDto?> HireDriverAsync(int id);
        Task<ResponseDto?> SackDriverAsync(int id);

    }
}
