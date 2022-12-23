using School.Base;

namespace School.Features.Assignments.Models;

public class AssignmentModel : Model
{
    public string Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    
}