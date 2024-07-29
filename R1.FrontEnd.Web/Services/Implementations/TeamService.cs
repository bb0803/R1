using R1.FrontEnd.Web.Services.Interfaces;
using R1.FrontEnd.Web.Static;
using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;
using System.Security.Cryptography.X509Certificates;
using R1.FrontEnd.Web.Models.Dto;

namespace R1.FrontEnd.Web.Services.Implementations
{
    public class TeamService : ITeamService
    {
       
        private readonly IBaseService _baseService;
        public TeamService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetAvailableStaffAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.TeamAPIBase + "/api/team/AvailableStaff"
            });
        }

        public async Task<ResponseDto?> GetTeamStatusAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.TeamAPIBase + "/api/team/teamStatus"
            });
        }

        public async Task<ResponseDto?> SetupWorldAsync(SetupWorldDto swDto)
        {
            try
            {
                return await _baseService.SendAsync(new RequestDto()
                {
                    ApiType = StaticDescriptions.ApiType.POST,
                    Url = StaticDescriptions.TeamAPIBase + $"/api/team/SetupWorld?TeamName={swDto.TeamName}&classId=6"
                });
            }
            catch (Exception ex)
            {
                ResponseDto responseDto = new ResponseDto();
                responseDto.Message = ex.Message;
                return responseDto;
            }

        }

        public async Task<ResponseDto?> PostTransactionAsync(Transaction tran)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = tran,
                Url = StaticDescriptions.TeamAPIBase + "/api/team/postTransaction"
            });
        }

        public async Task<ResponseDto?> HireStaffAsync(AvailableStaffDto staff)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = staff,
                Url = StaticDescriptions.TeamAPIBase + "/api/team/hireStaff"
            });
        }

        public async Task<ResponseDto?> SackStaffAsync(int staffId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = staffId,
                Url = StaticDescriptions.TeamAPIBase + "/api/team/sackStaff"
            });
        }
        public async Task<ResponseDto?> ChangeCarSettingsAsync(Chassis car)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = car,
                Url = StaticDescriptions.TeamAPIBase + "/api/team/changeCarSettings"
            });
        }

        public async Task<ResponseDto?> ChangeDriverSettingsAsync(Driver drv)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = drv,
                Url = StaticDescriptions.TeamAPIBase + "/api/team/changeDriverSettings"
            });
        }
    }
}
