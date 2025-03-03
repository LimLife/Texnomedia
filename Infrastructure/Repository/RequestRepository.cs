using System.Data.Common;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DBData _context;
        public RequestRepository(DBData context)
        {
            _context = context;
        }
        public async Task<Request> CreateReportAsync(Request report)
        {
            try
            {
                await _context.Request.AddAsync(report);
                await _context.SaveChangesAsync();
                return report;
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

        public async Task<List<Request>> GetAllReportsAsync()
        {
            try
            {
                return await _context.Request.AsNoTracking().ToListAsync();
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
