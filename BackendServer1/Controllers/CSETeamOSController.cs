using BackendServer1.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLoadBalancerSimulation.Database;
using ServerLoadBalancerSimulation.Database.Entities;

namespace BackendServer1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CSETeamOSController(AppDbContext dbContext, IConfiguration configuration) : ControllerBase
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IConfiguration _configuration = configuration;



    [HttpPost(Name = "")]
    public IActionResult Post([FromBody] CreateCSETeamRequestDto cseTeamOS)
    {
        var serverName = _configuration["SERVER_NAME"] ?? "UnknownServer";

        _dbContext.CSETeamOS.Add(new CSETeamOS
        {
            Name = cseTeamOS.Name,
            Group = cseTeamOS.Group,
            CourseName = cseTeamOS.CourseName
        });
        _dbContext.SaveChanges();
        return Ok(new
        {
            Server = serverName,
            CSETeamOS = cseTeamOS
        });
    }

    [HttpGet(Name = "")]
    public IActionResult Get()
    {
        var serverName = _configuration["SERVER_NAME"] ?? "UnknownServer";

        var cseTeamOS = _dbContext.CSETeamOS.ToList();
        return Ok(new
        {
            Server = serverName,
            CSETeamOS = cseTeamOS
        });

    }
}