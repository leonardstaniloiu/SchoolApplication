using System.ComponentModel.DataAnnotations;

namespace School.Features.Assignments.Views;

public class AssignmentsRequest
{
    [Required]public string Subject { get; set; }
    [Required]public string Description { get; set; }
    [Required]public DateTime Deadline { get; set; }
}