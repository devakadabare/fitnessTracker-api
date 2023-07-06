using System.Collections.Generic;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Services;
using API.DTO;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserService _userService;
    private readonly WeightLogService _weightLogService;

    public UserController(UserService userService, ILogger<UserController> logger, WeightLogService weightLogService)
    {
        _logger = logger;
        _userService = userService;
        _weightLogService = weightLogService;
    }

    [HttpGet(Name = "GetUser")]
    public List<User> Get()
    {
        //get all users from the database
        return new List<User>();
    }

    //add a new user
    [HttpPost]
    public async Task<ActionResult<User>> Post(UserRegistrationDTO user)
    {
        //create a new user
        var userResult = await _userService.CreateUserAsync(user);

        //create a new weight log
        var weightLogResult = await _weightLogService.CreateWeightLogAsync(
            new WeightLogCreationDTO
            {
                UserId = userResult.Id,
                Weight = userResult.Weight,
                Date = DateTime.Now
            }
        );

        return userResult;
        
    }
}
