using AutoMapper;
using AutoMapper.QueryableExtensions;
using R1.Services.API.Data;
using R1.Services.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using R1.Services.API.Models.Data;

namespace R1.Services.API.Repositories.Implementations
{
    public class ResultRepository : IResultRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ResultRepository> _logger;

        public ResultRepository(IAuthRepository authRepository, DataContext context, IMapper mapper, ILogger<ResultRepository> logger)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<SessionLapTime> GetSessionLapTimeDetailsAsync(int id)
        {
            var usr = await _authRepository.GetUserAsync();
            return await _context.SessionLapTimes.Where(s => s.SessionId == usr.CurrentWorldId)
                .ProjectTo<SessionLapTime>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<SessionLapTime>?> GetSessionLapTimesAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return await _context.SessionLapTimes.Where(s => s.SessionId == usr.CurrentWorldId)
                    .ToListAsync();
            } catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessionLapTimesAsync)}");
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }
    }
}
