using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class Test5Controller : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] { "Sunny2", "Cloudy2", "Rainy2" };
    }

    [HttpPost]
    public IActionResult Post([FromBody] TestData data)
    {
        if (data == null)
        {
            return BadRequest("Invalid data.");
        }

        return Ok(new { Message = "Data received successfully!", Data = data });
    }
}

public class TestData
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int Age { get; set; }
}
