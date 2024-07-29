using AutoMapper;
using AutoMapper.QueryableExtensions;
using R1.Services.API.Data;
using R1.Services.API.Models.Data;
using R1.Services.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using R1.Services.API.Models.User;

namespace R1.Services.API.Repositories.Implementations
{
    public class AuthRepository : GenericRepository<User>, IAuthRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext context;
        private readonly IMapper mapper;

        public AuthRepository(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, DataContext context, IMapper mapper) : base(context, mapper)
        {
            this._userManager = userManager;
            this.context = context;
            this.mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserSetting> GetUserAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            return await context.UserSettings
                .ProjectTo<UserSetting>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Username == userId);
        }
    }
}
