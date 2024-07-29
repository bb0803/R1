using R1.FrontEnd.Web.Services.Interfaces;
using R1.FrontEnd.Web.Static;
using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;

namespace R1.FrontEnd.Web.Services.Implementations
{
    public class ResultService : IResultService
    {
       
        private readonly IBaseService _baseService;
        public ResultService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetSessionLapTimesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.ResultAPIBase + "/api/result/Getall"
            });
        }

        public async Task<ResponseDto?> GetSessionLapTimeAsync(int Id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.ResultAPIBase + "/api/result"
            });
        }

    }
}
