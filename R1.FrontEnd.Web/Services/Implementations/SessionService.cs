using R1.FrontEnd.Web.Services.Interfaces;
using R1.FrontEnd.Web.Static;
using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;

namespace R1.FrontEnd.Web.Services.Implementations
{
    public class SessionService : ISessionService
    {
       
        private readonly IBaseService _baseService;
        public SessionService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> DoPracticeLapAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.SessionAPIBase + "/api/Session/DoPracticeLap"
            });
        }

        public async Task<ResponseDto?> DoQualifyingLapAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.SessionAPIBase + "/api/Session/DoQualifyingLap"
            });
        }

        public async Task<ResponseDto?> DoRaceLapAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.SessionAPIBase + "/api/Session/DoRaceLap"
            });
        }

        public async Task<ResponseDto?> CreateGridAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.SessionAPIBase + "/api/Session/CreateGrid"
            });
        }

        public async Task<ResponseDto?> ChangeCarSettingsAsync(Chassis car)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = car,
                Url = StaticDescriptions.SessionAPIBase + "/api/session/changeCarSettings"
            });
        }

        public async Task<ResponseDto?> ChangeDriverSettingsAsync(Driver drv)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = drv,
                Url = StaticDescriptions.SessionAPIBase + "/api/session/changeDriverSettings"
            });
        }

        public async Task<ResponseDto?> ChangeCarTyreAsync(int carTyre)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = carTyre,
                Url = StaticDescriptions.SessionAPIBase + "/api/session/ChangeCarTyre"
            });
        }

        public async Task<ResponseDto?> PitAsync(int chassisId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = chassisId,
                Url = StaticDescriptions.SessionAPIBase + "/api/session/pit"
            });
        }
    }
}
