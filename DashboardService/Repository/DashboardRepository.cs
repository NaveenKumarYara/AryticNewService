using Dapper;
using DashboardService.Context;
using DashboardService.Contracts;
using DashboardService.Entities;

namespace DashboardService.Repository
{
    public class DashboardRepository:IDashboardRepository
    {
        private readonly DapperContext _context;
        public DashboardRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfileNote>> GetProfileNote(long? ProfileId, int currentPageNumber, int pageSize)
        {
            int maxPagSize = 50;
            pageSize = (pageSize > 0 && pageSize <= maxPagSize) ? pageSize : maxPagSize;

            int skip = (currentPageNumber - 1) * pageSize;
            int take = pageSize;

            var query = "SELECT * FROM ProfileNotes WHERE ProfileId =  @ProfileId ORDER BY 1 DESC OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

            using (var connection = _context.CreateConnection())
            {
                var notes = await connection.QueryAsync<ProfileNote>(query, new { ProfileId, Skip = skip, Take = take });

                return notes.ToList();
            }
        }

        public async Task<IEnumerable<ProfileFeedback>> GetProfileFeedback(long? ProfileId, int currentPageNumber, int pageSize)
        {

            int maxPagSize = 50;
            pageSize = (pageSize > 0 && pageSize <= maxPagSize) ? pageSize : maxPagSize;

            int skip = (currentPageNumber - 1) * pageSize;
            int take = pageSize;



            var query = "SELECT * FROM ProfileFeedback WHERE ProfileId =  @ProfileId ORDER BY 1 DESC OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

            using (var connection = _context.CreateConnection())
            {
                var feedbacks = await connection.QueryAsync<ProfileFeedback>(query, new { ProfileId, Skip = skip, Take = take });

                return feedbacks.ToList();
            }
        }

        public async Task<IEnumerable<CandidateDocuments>> GetCandidateDocuments(long? ProfileId, int currentPageNumber, int pageSize)
        {

            int maxPagSize = 50;
            pageSize = (pageSize > 0 && pageSize <= maxPagSize) ? pageSize : maxPagSize;

            int skip = (currentPageNumber - 1) * pageSize;
            int take = pageSize;



            var query = "SELECT * FROM CandidateDocuments WHERE ProfileId =  @ProfileId ORDER BY 1 DESC OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

            using (var connection = _context.CreateConnection())
            {
                var feedbacks = await connection.QueryAsync<CandidateDocuments>(query, new { ProfileId, Skip = skip, Take = take });

                return feedbacks.ToList();
            }
        }
    }
}
