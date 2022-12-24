using System.ComponentModel.DataAnnotations;

namespace School.Features.Subjects.SubjectsViews;

public class SubjectsRequest
{
    [Required] public string Name { get; set; }
    
    [Required] public string ProfMail { get; set; }
    
    [Required] public List<Double> Grades { get; set; }
}