using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLoadBalancerSimulation.Database;
using ServerLoadBalancerSimulation.Database.Entities;

namespace BackendServer1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CSETeamOSController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext _dbContext = dbContext;

    [HttpPost(Name = "")]
    public IActionResult Post([FromBody] CSETeamOS cseTeamOS)
    {
        _dbContext.CSETeamOS.Add(cseTeamOS);
        _dbContext.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpGet(Name = "")]
    public IActionResult Get()
    {
        var cseTeamOS = _dbContext.CSETeamOS.ToList();
        return Ok(cseTeamOS);
    }
}
