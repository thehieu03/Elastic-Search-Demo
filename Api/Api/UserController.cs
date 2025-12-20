using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IElasticServices _elasticServices;

    public UserController(ILogger<UserController> logger, IElasticServices elasticServices)
    {
        _logger = logger;
        _elasticServices = elasticServices;
    }
    [HttpPost("create-index")]
    public async Task<IActionResult> CreateIndex(string index)
    {
        await _elasticServices.CreateIndexIfNotExistsAsync(index);
        return Ok($"Index {index} created or already exists");
    }
    [HttpPost("add-user")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        var result = await _elasticServices.AddOrUpdate(user);
        return result ? Ok("User add successfully") 
            : StatusCode(StatusCodes.Status500InternalServerError, "Error adding user");
    }
    [HttpPost("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        var result = await _elasticServices.AddOrUpdate(user);
        return result ? Ok("User add successfully") 
            : StatusCode(StatusCodes.Status500InternalServerError, "Error adding user");
    }
}