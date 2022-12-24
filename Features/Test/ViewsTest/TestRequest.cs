using System.ComponentModel.DataAnnotations;

namespace School.Features.Test.ViewsTest;

public class TestRequest
{
    [Required] public string Subject { get; set; }
    [Required] public DateTime DateTest { get; set; }
}