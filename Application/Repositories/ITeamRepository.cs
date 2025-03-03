namespace Application.Repositories
{
    public interface ITeamRepository
    {

        public Task<Team> CreateOrderAsync(Team team);
        public Task<List<Team>> GetAllOrdersAsync();
    }
}
