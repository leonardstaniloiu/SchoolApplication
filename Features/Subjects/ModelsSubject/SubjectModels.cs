using School.Base;

namespace School.Features.Subjects.ModelsSubject;

public class SubjectModels : Model
{
    public string Name { get; set; }
    public string ProfessorMail { get; set; }
    public List<Double> Grades { get; set; }
}