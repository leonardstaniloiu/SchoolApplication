using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using School.Features.Subjects.ModelsSubject;
using School.Features.Subjects.SubjectsViews;
using School.Base;
namespace School.Features.Subjects;

[ApiController]
[Route("Subjects")]

public class SubjectsController
{

    private static List<SubjectModels> _mockDb = new List<SubjectModels>();


    public SubjectsController()
    {
    }

    [HttpPost]

    public SubjectsResponse Add(SubjectsRequest request)
    {
        var subject = new SubjectModels()
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Name = request.Name,
            ProfessorMail = request.ProfMail,
            Grades = request.Grades
        };

        _mockDb.Add(subject);

        return new SubjectsResponse()
        {
            Id = subject.Id,
            Name = subject.Name,
            ProfMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }

    [HttpGet]

    public IEnumerable<SubjectsResponse> Get()
    {
        return _mockDb.Select(
            subject => new SubjectsResponse()
            {
                Id = subject.Id,
                Name = subject.Name,
                ProfMail = subject.ProfessorMail,
                Grades = subject.Grades
            }).ToList();
    }

    [HttpGet("{id}")]

    public SubjectsResponse Get([FromRoute] string id)
    {
        var subject = _mockDb.FirstOrDefault(x => x.Id == id);
        if (subject is null)
            return null;

        return new SubjectsResponse()
        {
            Id = subject.Id,
            Name = subject.Name,
            ProfMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }

    [HttpDelete]

        public SubjectsResponse Delete([FromRoute] string id)
        {
            var subject = _mockDb.FirstOrDefault(x => x.Id == id);
            if (subject is null)
                return null;

            return new SubjectsResponse()
            {
                Success = true,
                Id = subject.Id,
                Name = subject.Name,
                ProfMail = subject.ProfessorMail,
                Grades = subject.Grades
            };
        }

        [HttpPatch("{id}")]

        public SubjectsResponse Update([FromRoute] string id, [FromBody] SubjectsRequest request)
        {
            var subject = _mockDb.FirstOrDefault(user => user.Id == id);
            if (subject is null)
                return null;

            subject.Updated = DateTime.UtcNow;
            subject.Name = subject.Name;
            subject.ProfessorMail = subject.ProfessorMail;
            subject.Grades = subject.Grades;
            
            return new SubjectsResponse()
            {
                Success = true,
                Id = subject.Id,
                Name = subject.Name,
                ProfMail = subject.ProfessorMail,
                Grades = subject.Grades
            };
        }
        
    }

