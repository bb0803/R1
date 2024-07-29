using AutoMapper;
using AutoMapper.QueryableExtensions;
using R1.Services.API.Data;
using R1.Services.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using R1.Services.API.Models.Data;
using R1.Services.API.Models.Dto;
using System.Text.RegularExpressions;
using R1.Services.API.Models.User;

namespace R1.Services.API.Repositories.Implementations
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TeamRepository> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public TeamRepository(IAuthRepository authRepository, DataContext context, IMapper mapper, ILogger<TeamRepository> logger, IHttpContextAccessor contextAccessor)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
            this._contextAccessor = contextAccessor;
        }

        public Task<int> ChangeCarSettingsAsync()
        {
            return _context.Database.ExecuteSqlAsync($"ChangeCarSetting"); ;
        }

        public async Task<DriverSetting> ChangeDriverSettingsAsync(int DriverId)
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return await _context.DriverSettings.Where(e => e.DriverId == DriverId)
                    .ProjectTo<DriverSetting>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(ChangeDriverSettingsAsync)}");
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }

        public async Task<List<StaffDto>> GetAvailableStaffAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var result = _context.Database.SqlQuery<StaffDto>($"Exec GetAvailableStaff @Username = {usr.Username}, @ClassId = 6").AsEnumerable().ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAvailableStaffAsync)}");
                return null; 
            }
        }

        public async Task<Team> GetTeamStatusAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return await _context.Teams.Where(e => e.Id == usr.CurrentTeamId)
                    .ProjectTo<Team>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetTeamStatusAsync)}");
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }

        public async Task<int> HireStaffAsync(AvailableStaffDto staff)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<int>($"Exec HireStaff @Username = {UserName}, @StaffId = {staff.Id}, @StaffName = {staff.StaffName}, @StaffRating = {staff.Rating}, @StaffSalary = {staff.Salary} ").AsEnumerable().FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(HireStaffAsync)}." + ex.Message);
                return 0;
            }
        }

        public Task<int> PostTransactionAsync(Transaction tran)
        {
            return _context.Database.ExecuteSqlAsync($"PostTransaction {tran.Cost}"); ;
        }

        public Task<int> SackStaffAsync(int staffId)
        {
            return _context.Database.ExecuteSqlAsync($"SackStaff {staffId}");
        }

        public async Task<UserSetting> SetupWorldAsync(String teamName, int classId)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<UserSetting>($"Exec SetupWorld @Username={UserName} , @TeamName = {teamName}, @ClassId = {classId}").AsEnumerable().FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(SetupWorldAsync)}");
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }
    }
}
