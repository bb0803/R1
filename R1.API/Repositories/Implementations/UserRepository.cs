using AutoMapper;
using AutoMapper.QueryableExtensions;
using R1.Services.API.Data;
using R1.Services.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using R1.Services.API.Models.Data;
using R1.Services.API.Models.User;
using R1.Services.API.Models.Dto;

namespace R1.Services.API.Repositories.Implementations
{
    public class UserRepository : GenericRepository<UserSetting>, IUserRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepository> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IHttpContextAccessor httpContextAccessor, IAuthRepository authRepository, DataContext context, IMapper mapper, ILogger<UserRepository> logger) : base (context, mapper)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public Task<UserSetting> ChangeSession(int? SessionId)
        {
            throw new NotImplementedException();
        }

        public Task<UserSetting> ChangeTeam(int TeamId)
        {
            throw new NotImplementedException();
        }

        public Task<UserSetting> ChangeWorld(int WorldId)
        {
            throw new NotImplementedException();
        }

        public async Task<StatusDto> CheckStatus()
        {
            string username = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var result = _context.Database.SqlQuery<StatusDto>($"Exec CheckStatus @Username = {username}").AsEnumerable().FirstOrDefault();
            return result;
        }

        public async Task<UserSetting> GetUserSetting()
        {
            return await _context.UserSettings.Where(u => u.Username == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value).FirstOrDefaultAsync();
        }
    }
}
