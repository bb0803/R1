using R1.Services.API.Models.User;
using R1.Services.API.Data;


namespace R1.Services.API.Repositories.Interfaces
{
    public interface IAuthRepository : IGenericRepository<User>
    {
        Task<UserSetting> GetUserAsync();
    }
}
