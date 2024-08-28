using Microsoft.AspNetCore.Mvc;

namespace ETrade.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController(IConfiguration configuration) : ControllerBase
{
    readonly IConfiguration _configuration = configuration;

    [HttpGet("[action]")]
    public IActionResult GetBaseStorageUrl()
    {
        return Ok(new
        {
            Url = _configuration["BaseStorageUrl"]
        });
    }

}
