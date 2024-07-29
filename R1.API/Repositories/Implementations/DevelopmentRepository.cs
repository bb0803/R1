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
    public class DevelopmentRepository : IDevelopmentRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DevelopmentRepository> _logger;

        public DevelopmentRepository(IAuthRepository authRepository, DataContext context, IMapper mapper, ILogger<DevelopmentRepository> logger)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        public Task<int> StartTask(int TaskId)
        {
            return _context.Database.ExecuteSqlAsync($"PurchaseEngine {TaskId}");
        }

        public Task<int> EndOfRound()
        {
            return _context.Database.ExecuteSqlAsync($"PurchaseEngine");
        }
    }
}
