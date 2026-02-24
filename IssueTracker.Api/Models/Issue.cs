namespace IssueTracker.Api.Models
{
    public class Issue
    {

      public int   Id { get; set; }
      
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

       
    }
}
