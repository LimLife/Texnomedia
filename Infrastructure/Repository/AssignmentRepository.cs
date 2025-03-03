using System.Data.Common;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly DBData _context;
        public AssignmentRepository(DBData context)
        {
            _context = context;
        }

        public async Task<Assignment> AssignOrderToBrigadeAsync(Assignment assignment)
        {
            try
            {
                await _context.Assignments.AddAsync(assignment);
                await _context.SaveChangesAsync();
                return assignment;
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Не удалось добавить задание в базу данных.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Произошла непредвиденная ошибка.", ex);
            }
        }

        public async Task<List<Assignment>> GetAllAssignmentsAsync()
        {
            try
            {
                return await _context.Assignments.AsNoTracking().ToListAsync();

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
