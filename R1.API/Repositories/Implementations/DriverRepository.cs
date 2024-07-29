using AutoMapper;
using AutoMapper.QueryableExtensions;
using R1.Services.API.Data;
using R1.Services.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using R1.Services.API.Models.Data;
using System.Threading.Tasks;

namespace R1.Services.API.Repositories.Implementations
{
    public class DriverRepository : IDriverRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TeamRepository> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public DriverRepository(IAuthRepository authRepository, DataContext context, IMapper mapper, ILogger<TeamRepository> logger, IHttpContextAccessor contextAccessor)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
            this._contextAccessor = contextAccessor;
        }

        public async Task<List<Driver>> GetAvailableDriversAsync()
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<Driver>($"Exec GetAvailableDrivers @Username={UserName}, @ClassId = 6").AsEnumerable().ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAvailableDriversAsync)}." + ex.Message);
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }

        public async Task<int> ChangeDriverSettingsAsync(Driver drv)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Driver>> GetTeamDriversAsync()
        {
            return _context.Drivers.FromSql($"GetTeamDrivers").ToList();
        }

        public async Task<int> HireDriverAsync(int driverId)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<int>($"Exec HireDriver @Username = {UserName}, @DriverId = {driverId}").AsEnumerable().FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(HireDriverAsync)}." + ex.Message);
                return 0;
            }
        }

        public async Task<int> SackDriverAsync(int driverId)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<int>($"Exec SackDriver @Username = {UserName}, @DriverId = {driverId}").AsEnumerable().FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(SackDriverAsync)}." + ex.Message);
                return 0;
            }
        }
    }
}
