

namespace Application.Repositories
{
    public interface IAssignmentRepository 
    {
        public Task<Assignment> AssignOrderToBrigadeAsync(Assignment assignment);

        public Task<List<Assignment>> GetAllAssignmentsAsync();

    }
}
