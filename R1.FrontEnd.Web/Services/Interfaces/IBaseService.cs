using R1.FrontEnd.Web.Models.API;

namespace R1.FrontEnd.Web.Services.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
        
    }
}
