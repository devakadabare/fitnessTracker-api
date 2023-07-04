using System.Collections.Generic;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUser")]
    public List<User> Get()
    {
        //get all users from the database
        return new List<User>();
    }

    //add a new user
    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest();
        }

        //add the user to the database
        return CreatedAtRoute("GetUser", new { id = user.Id }, user);
    }
}
