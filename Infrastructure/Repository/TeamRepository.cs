using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infrastructure.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DBData _context;
        public TeamRepository(DBData context)
        {
            _context = context;
        }
        public async Task<Team> CreateOrderAsync(Team team)
        {
            try
            {
                await _context.Team.AddAsync(team);
                await _context.SaveChangesAsync();
                return team;
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Не удалось добавить бригаду в базу данных.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Произошла непредвиденная ошибка.", ex);
            }

        }

        public async Task<List<Team>> GetAllOrdersAsync()
        {
            try
            {
                return await _context.Team.AsNoTracking().ToListAsync();
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Не удалось получить бригаду из базы данных.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Произошла непредвиденная ошибка.", ex);
            }

        }
    }
}
