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
    public class CarRepository : ICarRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CarRepository> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public CarRepository(IAuthRepository authRepository, DataContext context, IMapper mapper, ILogger<CarRepository> logger, IHttpContextAccessor contextAccessor)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
            this._contextAccessor = contextAccessor;
        }


        //From Here
        public async Task<Engine> GetCurrentEngineAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return await _context.Engines.Where(e => e.WorldId == usr.CurrentWorldId)
                    .ProjectTo<Engine>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(q => q.TeamId == usr.CurrentTeamId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCurrentEngineAsync)}");
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }

        public async Task<Chassis> GetCurrentChassisAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return await _context.Chassis.Where(e => e.WorldId == usr.CurrentWorldId)
                    .ProjectTo<Chassis>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(q => q.TeamId == usr.CurrentTeamId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCurrentChassisAsync)}");
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }

        public async Task<List<AvailableEngineDto>> GetAvailableEnginesAsync()
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<AvailableEngineDto>($"Exec GetAvailableEngines @ClassId = 6").AsEnumerable().ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAvailableEnginesAsync)}." + ex.Message);
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }

        public async Task<List<AvailableChassisDto>> GetAvailableChassisAsync()
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<AvailableChassisDto>($"Exec GetAvailableChassis @ClassId = 6").AsEnumerable().ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAvailableChassisAsync)}." + ex.Message);
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }


        public async Task<int> PurchaseEngineAsync(int engineId)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<int>($"Exec PurchaseEngine @Username = {UserName}, @EngineId = {engineId}").AsEnumerable().FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(PurchaseEngineAsync)}." + ex.Message);
                return 0;
            }
        }

        public async Task<int> PurchaseChassisAsync(int chassisId)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<int>($"Exec PurchaseChassis @Username = {UserName}, @ChassisId = {chassisId}").AsEnumerable().FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(PurchaseChassisAsync)}." + ex.Message);
                return 0;
            }
        }

        public async Task<string> GetPartStatusAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAvailablePartsAsync()
        {
            throw new NotImplementedException();
        }

    }
}
