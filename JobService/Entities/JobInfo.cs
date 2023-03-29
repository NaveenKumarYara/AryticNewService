using MailChimp.Net.Models;

namespace JobService.Entities
{
    public class JobInfo
    {
        
        public long JobInfoId { get; set; }
        public long JobId { get; set; }
        public string? JobPositionId { get; set; }
        public long UserId { get; set; }
        public long CustomerId { get; set; }
        public Nullable<int> JobCategoryId { get; set; }
        public string? JobTitle { get; set; }
        public int MinExperienceId { get; set; }
        public int MaxExperienceId { get; set; }
        public Nullable<bool> CompleteDescription { get; set; }
        public string? JobDescription { get; set; }
        public Nullable<int> NumberOfVacancies { get; set; }
        public Nullable<int> HiringProcessId { get; set; }
        public Nullable<long> HiringManagerId { get; set; }
        public string? KeyWords { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> FunctionalAreaId { get; set; }
        public Nullable<int> JobRoleId { get; set; }
        public Nullable<int> RemoteWorkId { get; set; }
        public Nullable<bool> Travel { get; set; }
        public Nullable<decimal> TravelPercentage { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsPrivate { get; set; }
        public Nullable<int> StepNumber { get; set; }
        public Nullable<bool> IsDrafted { get; set; }
        public System.DateTime PostedDate { get; set; }
        public long PostedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<bool> IsTemplate { get; set; }
        public Nullable<int> IsOpen { get; set; }
        public Nullable<long> VideoSizzleId { get; set; }
        public string? TemplateSaveTitle { get; set; }
        public Nullable<int> JobPriority { get; set; }
        public Nullable<int> JobDueDateId { get; set; }

   
    
   }
}
