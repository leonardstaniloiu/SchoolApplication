namespace School.Features.Assignments.Views;

public class AssignmentsResponse
{
    public string Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public bool Success { get; set; }
    public string Mesaj { get; set; }
}