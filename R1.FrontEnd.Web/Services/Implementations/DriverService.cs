using R1.FrontEnd.Web.Services.Interfaces;
using R1.FrontEnd.Web.Static;
using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Dto;

namespace R1.FrontEnd.Web.Services.Implementations
{
    public class DriverService : IDriverService
    {
        private readonly IBaseService _baseService;
        public DriverService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetTeamDriversAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.DriverAPIBase + "/api/driver/teamDrivers"
            });
        }

        public async Task<ResponseDto?> GetAvailableDriversAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.DriverAPIBase + "/api/driver/availableDrivers"
            });
        }

        public async Task<ResponseDto?> HireDriverAsync(int driverId)
        {
            HireDriverDto dto = new HireDriverDto { driverId = driverId };
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = dto,
                Url = StaticDescriptions.DriverAPIBase + "/api/driver/hireDriver"
            });
        }

        public async Task<ResponseDto?> SackDriverAsync(int driverId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Data = driverId,
                Url = StaticDescriptions.DriverAPIBase + "/api/driver/sackDriver"
            });
        }
    }
}
