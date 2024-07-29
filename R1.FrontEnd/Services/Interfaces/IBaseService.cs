using R1.FrontEnd.WA.Models.API;
using R1.FrontEnd.WA.Models;

namespace R1.FrontEnd.WA.Services.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
        
    }
}
