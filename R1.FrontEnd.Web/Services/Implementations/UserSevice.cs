using R1.FrontEnd.Web.Services.Interfaces;
using R1.FrontEnd.Web.Static;
using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;

namespace R1.FrontEnd.Web.Services.Implementations
{
    public class UserService : IUserService
    {
       
        private readonly IBaseService _baseService;
        public UserService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CheckStatusAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.DevelopmentAPIBase + "/api/user/checkStatus"
            });
        }
    }
}
