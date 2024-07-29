using R1.Services.API.Models.Data;

namespace R1.Services.API.Repositories.Interfaces
{
    public interface IDevelopmentRepository 
    {
        Task<int> StartTask(int TaskId);

        Task<int> EndOfRound();
    }
}
