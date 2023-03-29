using JobService.Entities;

namespace JobService.Contracts
{
    public interface IJobRepository
    {
        public Task<IEnumerable<JobInfo>> GetCustomerJobs(long? CustomerId, long? UserId, int currentPageNumber, int pageSize);
    }
}
