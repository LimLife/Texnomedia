using Microsoft.EntityFrameworkCore;
using Application.Repositories;
using Application.Entity;
using System.Data.Common;


namespace Infrastructure.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly DBData _context;
        public StatisticsRepository(DBData context)
        {
            _context = context;
        }
        public async Task<List<TeamStatistics>> GetMonthlyStatisticsAsync(DateTime start, DateTime end)
        {
            try
            {
                var statistics = await _context.Assignments
               .Where(r => r.AssignmentDate >= start && r.CompletionDate <= end)
               .Where(r => r.Status == Entity.Enums.AssignmentStatus.Completed)
               .Include(r => r.Team)
               .GroupBy(r => r.Team.Name)
               .Select(t => new TeamStatistics()
               {
                   TeamName = t.Key,
                   CompletedAssignments = t.Count(),
                   //fixed need
                   TotalHoursSpent = t.Sum(s => (s.AssignmentDate.Ticks - s.CompletionDate.Ticks)) / TimeSpan.TicksPerMicrosecond / 1000 / 60
               })
               .ToListAsync();

                return statistics;
            }
            catch (DbException ex)
            {

                throw new ApplicationException("Не удалось получить задания из базы данных.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Произошла непредвиденная ошибка.", ex);
            }

        }
    }
}
