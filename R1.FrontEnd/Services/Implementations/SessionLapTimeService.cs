using static R1.FrontEnd.WA.Services.Implementations.SessionLapTimeService;
using R1.FrontEnd.WA.Services.Interfaces;
using R1.FrontEnd.WA.Static;
using R1.FrontEnd.WA.Models.API;
using R1.FrontEnd.WA.Models.Data;

namespace R1.FrontEnd.WA.Services.Implementations
{
    public class SessionLapTimeService : ISessionLapTimeService
    {
       
        private readonly IBaseService _baseService;
        public SessionLapTimeService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateSessionLapTimeAsync(SessionLapTime sessionLapTimeDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = sessionLapTimeDto,
                Url = StaticDescriptions.SessionLapTimeAPIBase + "/api/sessionLapTimes"
            });
        }

        public async Task<ResponseDto?> DeleteSessionLapTimeAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.DELETE,
                Url = StaticDescriptions.SessionLapTimeAPIBase + "/api/sessionLapTimes/" + id
            });
        }

        public async Task<ResponseDto?> GetAllSessionLapTimesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.SessionLapTimeAPIBase + "/api/SessionLapTimes/Getall"
            });
        }

        public async Task<ResponseDto?> GetSessionLapTimeAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.SessionLapTimeAPIBase + "/api/sessionLapTimes/" + id
            });
        }

        public async Task<ResponseDto?> UpdateSessionLapTimeAsync(SessionLapTime sessionLapTimeDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.PUT,
                Data = sessionLapTimeDto,
                Url = StaticDescriptions.SessionLapTimeAPIBase + "/api/sessionLapTimes"
            });
        }

        //public async Task<VirtualizeResponse<SessionLapTime>> GetVirtualSessionLapTimesAsync(QueryParameters param)
        //{
        //    return await _baseService.SendAsync(new VirtualizeResponse<SessionLapTime>()
        //    {
        //        ApiType = StaticDescriptions.ApiType.GET,
        //        Url = StaticDescriptions.SessionLapTimeAPIBase + "/api/SessionLapTimes/?startIndex=" + param.StartIndex.ToString() + "&pageSize=" + param.PageSize.ToString()
        //    });
        //}
    }
}
