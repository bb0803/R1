using R1.FrontEnd.Web.Services.Interfaces;
using R1.FrontEnd.Web.Static;
using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;
using R1.FrontEnd.Web.Models.Dto;

namespace R1.FrontEnd.Web.Services.Implementations
{
    public class CarService : ICarService
    {
       
        private readonly IBaseService _baseService;
        public CarService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetCurrentEngineAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.CarAPIBase + "/api/car/CurrentEngine"
            });
        }

        public async Task<ResponseDto?> GetCurrentChassisAsync()
        {
            return await _baseService.SendAsync(new RequestDto()

            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.CarAPIBase + "/api/car/CurrentChassis"
            });
        }

        public async Task<ResponseDto?> GetAvailableEnginesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.CarAPIBase + "/api/car/AvailableEngines"
            });
        }

        public async Task<ResponseDto?> GetAvailableChassisAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.CarAPIBase + "/api/car/AvailableChassis"
            });
        }

        public async Task<ResponseDto?> PurchaseEngineAsync(int engineId)
        {
            PurchaseEngineDto dto = new PurchaseEngineDto { engineId = engineId };
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = dto,
                Url = StaticDescriptions.CarAPIBase + "/api/car/PurchaseEngine"
            });
        }
        public async Task<ResponseDto?> PurchaseChassisAsync(int chassisId)
        {
            PurchaseChassisDto dto = new PurchaseChassisDto { chassisId = chassisId };
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.POST,
                Data = dto,
                Url = StaticDescriptions.CarAPIBase + "/api/car/PurchaseChassis"
            });
        }

        public async Task<ResponseDto?> GetPartStatusAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.CarAPIBase + "/api/car/PartStatus"
            });
        }

        public async Task<ResponseDto?> GetAvailablePartsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDescriptions.ApiType.GET,
                Url = StaticDescriptions.CarAPIBase + "/api/car/AvailableParts"
            });
        }
    }
}
