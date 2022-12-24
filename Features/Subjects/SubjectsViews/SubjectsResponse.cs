namespace School.Features.Subjects.SubjectsViews;

public class SubjectsResponse
{
    public bool Success { get; set; }
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string ProfMail { get; set; }
    
    public List<Double> Grades { get; set; }
    
}