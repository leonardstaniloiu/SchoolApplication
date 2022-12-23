using Microsoft.AspNetCore.Mvc;
using School.Features.Assignments.Models;
using School.Features.Assignments.Views;

namespace School.Features.Assignments;

[ApiController]
[Route("assignments")]
public class AssignmentsController
{
    private static List<AssignmentModel> _mockDb = new List<AssignmentModel>(); //Nu avem baza de date, deci folosim o list pe post de DB de asta avem mockDb

    public AssignmentsController() { }

    [HttpPost] //Tag-ul adauga informatii in baza de date
    public AssignmentsResponse Add(AssignmentsRequest request)
    {
        var assignment = new AssignmentModel
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            Description = request.Description,
            Deadline = request.Deadline
        };
        
        _mockDb.Add(assignment);

        return new AssignmentsResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline,   
        };
    }

    [HttpGet]
    public IEnumerable<AssignmentsResponse> Get()
    {
        return _mockDb.Select(
            assignment => new AssignmentsResponse
            {
                Id = assignment.Id,
                Subject = assignment.Subject,
                Description = assignment.Description,
                Deadline = assignment.Deadline
            }).ToList();
    }

    [HttpGet("{id}")]
    public AssignmentsResponse Get([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.Id == id);
        if (assignment is null)
        {
            return null;
        }
        return new AssignmentsResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }
    //[HttpDelete]
    [HttpDelete("{id}")]
    public AssignmentsResponse Delete([FromRoute] string id)
    {
        var id_cautat = _mockDb.FirstOrDefault(x => x.Id == id);
        
        if (id_cautat is null)
        {
            return null;
        }

        _mockDb.Remove(id_cautat);

        return new AssignmentsResponse()
        {
            Success = true,
            Mesaj = $"Inregistrarea id-ului {id} a fost stearsa cu succes!",
            Id = id_cautat.Id,
            Subject = id_cautat.Subject,
            Description = id_cautat.Description,
            Deadline = id_cautat.Deadline

        };
    }
    //[HttpPatch]
    [HttpPatch("{id}")]
    public AssignmentsResponse Patch([FromRoute] string id, [FromBody] AssignmentsResponse request)
    {
        var id_cautat = _mockDb.FirstOrDefault(x => x.Id == id);

        if (id_cautat is null)
        {
            return null;
        }

        id_cautat.Subject = request.Subject;
        id_cautat.Description = request.Description;
        id_cautat.Deadline = request.Deadline;
        id_cautat.Id = request.Id;

        return new AssignmentsResponse()
        {
            Success = true,
            Mesaj = $"Inregistrarea id-ului {id} a fost modificata cu succes!",
            Id = id_cautat.Id,
            Subject = id_cautat.Subject,
            Description = id_cautat.Description,
            Deadline = id_cautat.Deadline
        };
    }

}