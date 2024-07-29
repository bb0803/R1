using AutoMapper;
using AutoMapper.QueryableExtensions;
using R1.Services.API.Data;
using R1.Services.API.Models.Data;
using R1.Services.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace R1.Services.API.Repositories.Implementations
{
    public class SessionRepository : ISessionRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<SessionRepository> _logger;

        public SessionRepository(IAuthRepository authRepository, DataContext context, IMapper mapper, ILogger<SessionRepository> logger)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        public Task<int> ChangeCarSettingAsync(Chassis car)
        {
            return _context.Database.ExecuteSqlAsync($"ChangeDriverSettings {car.Id}");
        }

        public Task<int> ChangeCarTyreAsync(int CarTyre)
        {
            return _context.Database.ExecuteSqlAsync($"ChangeCarTyre {CarTyre}");
        }

        public Task<int> ChangeDriverSettingsAsync(Driver drv)
        {
            return _context.Database.ExecuteSqlAsync($"ChangeDriverSettings {drv.Id}");
        }

        public async Task<List<RaceGrid>> CreateGridAsync()
        {
            return _context.RaceGrids.FromSql($"CreateGrid").ToList();
        }

        public async Task<List<SessionLapTime>> DoPracticeLapAsync()
        {
            return _context.SessionLapTimes.FromSql($"DoPracticeLap").ToList();
        }

        public async Task<List<SessionLapTime>> DoQualifyingLapAsync()
        {
            return _context.SessionLapTimes.FromSql($"DoQualifyingLap").ToList();
        }

        public async Task<List<SessionLapTime>> DoRaceLapAsync()
        {
            return _context.SessionLapTimes.FromSql($"DoRaceLap").ToList();
        }

        public Task<int> PitAsync()
        {
            return _context.Database.ExecuteSqlAsync($"Pit");
        }
    }
}
