namespace DashboardService.Entities
{
    public class CandidateDocuments
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public long? Id { get; set; }
        public string? DocUrl { get; set; }
        public long? ProfileId { get; set; }
        public long? JobId { get; set; }

        public string? DocName { get; set; }
    }
}
