namespace DashboardService.Entities
{
    public class ProfileNote
    {
        public string? CustomerComment { get; set; }
        public string? CandidateComment { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string? JobTitle { get; set; }
        public string? ReferralStatus { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long? CustomeruserId { get; set; }
        public string? ToUserId { get; set; }
        public bool? IsCandidate { get; set; }
        public long? JobId { get; set; }

        public long? ProfileId { get; set; }

        public long? NotesId { get; set; }

        public string? DocUrl { get; set; }
        public string? Others { get; set; }
    }
}
