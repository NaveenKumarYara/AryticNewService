using DashboardService.Entities;

namespace DashboardService.Contracts
{
    public interface IDashboardRepository
    {
        public Task<IEnumerable<ProfileNote>> GetProfileNote(long? ProfileId, int currentPageNumber, int pageSize);

        public Task<IEnumerable<ProfileFeedback>> GetProfileFeedback(long? ProfileId, int currentPageNumber, int pageSize);

        public Task<IEnumerable<CandidateDocuments>> GetCandidateDocuments(long? ProfileId, int currentPageNumber, int pageSize);
    }
}
