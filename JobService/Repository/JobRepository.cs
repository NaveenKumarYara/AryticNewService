using Dapper;
using JobService.Context;
using JobService.Contracts;
using JobService.Entities;
using MailChimp.Net.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;
namespace JobService.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly DapperContext _context;
        private  string? customerjobquery;
        public JobRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<JobInfo>> GetCustomerJobs(long? CustomerId, long? UserId, int currentPageNumber, int pageSize)
        {
            int maxPagSize = 50;
            pageSize = (pageSize > 0 && pageSize <= maxPagSize) ? pageSize : maxPagSize;

            int skip = (currentPageNumber - 1) * pageSize;
            int take = pageSize;
            //customerjobquery = ConfigurationManager.AppSettings["CustomerJobs"];
            customerjobquery = "SELECT * FROM JobInfo WHERE CustomerId =  @CustomerId AND UserId=@UserId ORDER BY 1 DESC OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
            using (var connection = _context.CreateConnection())
            {
                var notes = await connection.QueryAsync<JobInfo>(customerjobquery, new {CustomerId, UserId, Skip = skip, Take = take });

                return notes.ToList();
            }
        }
    }
}
