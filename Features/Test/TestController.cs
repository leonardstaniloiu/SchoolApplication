using Microsoft.AspNetCore.Mvc;
using School.Features.Test.ModelsTest;
using School.Features.Test.ViewsTest;

namespace School.Features.Test;

[ApiController]
[Route("Test")]
public class TestController
{
    private static List<TestModels> _mockDb = new List<TestModels>();

    [HttpPost]

    public TestResponse Add(TestRequest request)
    {
        var test = new TestModels()
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            DateTest = request.DateTest
        };
        
        _mockDb.Add(test);

        return new TestResponse()
        {
            Id = test.Id,
            Subject = test.Subject,
            DateTest = test.DateTest,

        };
    }

    [HttpGet]
    
    public IEnumerable<TestResponse> Get()
    {
        return _mockDb.Select(
            test => new TestResponse
            {
                Id = test.Id,
                Subject = test.Subject,
                DateTest = test.DateTest
            }
        ).ToList();
    }

    [HttpGet("{id}")]

    public TestResponse Get([FromRoute] string id)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);

        if (test is null)
            return null;

        return new TestResponse()
        {
            Id = test.Id,
            Subject = test.Subject,
            DateTest = test.DateTest
        };

    }
    
    [HttpDelete]
    
    public TestResponse Delete([FromRoute] string id)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);

        if (test is null)
            return null;

        _mockDb.Remove(test);
        
        return new TestResponse()
        {
            Id = test.Id,
            Subject = test.Subject,
            DateTest = test.DateTest
        };

    }

    [HttpPatch("{id}")]

    public TestResponse Update([FromRoute] string id, [FromBody] TestRequest request)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);

        if (test is null)
            return null;

        test.Updated = DateTime.UtcNow;
        test.Subject = request.Subject;
        test.DateTest = request.DateTest;

        return new TestResponse()
        {
            Id = test.Id,
            Subject = test.Subject,
            DateTest = test.DateTest
        };

    }
}