using Application.Entity;

namespace Application.Repositories
{
    public interface IStatisticsRepository
    {
        public Task<List<TeamStatistics>> GetMonthlyStatisticsAsync(DateTime start, DateTime end);
    }
}
