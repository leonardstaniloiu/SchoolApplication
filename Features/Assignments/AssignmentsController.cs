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
        var IdCautat = _mockDb.FirstOrDefault(x => x.Id == id);
        
        if (IdCautat is null)
        {
            return null;
        }

        _mockDb.Remove(IdCautat);

        return new AssignmentsResponse()
        {
            Id = IdCautat.Id,
            Subject = IdCautat.Subject,
            Description = IdCautat.Description,
            Deadline = IdCautat.Deadline

        };
    }
    //[HttpPatch]
    [HttpPatch("{id}")]
    public AssignmentsResponse Patch([FromRoute] string id, [FromBody] AssignmentsResponse request)
    {
        var IdCautat = _mockDb.FirstOrDefault(x => x.Id == id);

        if (IdCautat is null)
        {
            return null;
        }

        IdCautat.Subject = request.Subject;
        IdCautat.Description = request.Description;
        IdCautat.Deadline = request.Deadline;
        IdCautat.Id = request.Id;

        return new AssignmentsResponse()
        {
            Id = IdCautat.Id,
            Subject = IdCautat.Subject,
            Description = IdCautat.Description,
            Deadline = IdCautat.Deadline
        };
    }

}