using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Api.Dtos
{
    public class IssueDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

    }
}
