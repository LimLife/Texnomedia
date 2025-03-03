namespace Application.Repositories
{
    public interface IRequestRepository
    {
        public Task<Request> CreateReportAsync(Request report);
        public Task<List<Request>> GetAllReportsAsync();
    }
}
