using R1.FrontEnd.Web.Services.Interfaces;
using R1.FrontEnd.Web.Static;
using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;

namespace R1.FrontEnd.Web.Services.Implementations
{
    public class DevelopmentService : IDevelopmentService
    {
       
        private readonly IBaseService _baseService;
        public DevelopmentService(IBaseService baseService)
        {
            _baseService = baseService;
        }



        public async Task<ResponseDto?> StartTaskAsync(int taskId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.PUT,
                Data = taskId,
                Url = StaticDescriptions.DevelopmentAPIBase + "/api/development/startTask"
            });
        }

        public async Task<ResponseDto?> EndOfRoundAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.PUT,
                Url = StaticDescriptions.DevelopmentAPIBase + "/api/development/endOfRound"
            });
        }
    }
}
