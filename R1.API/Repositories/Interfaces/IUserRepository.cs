using R1.Services.API.Models.Dto;
using R1.Services.API.Models.User;

namespace R1.Services.API.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<UserSetting>
    {
        Task<UserSetting> ChangeWorld(int WorldId);

        Task<UserSetting> ChangeTeam(int TeamId);

        Task<UserSetting> ChangeSession(int? SessionId);

        Task<UserSetting> GetUserSetting();

        Task<StatusDto> CheckStatus();
    }
}
