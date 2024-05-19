using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using barberdotnet.model.entities;

namespace barberdotnet.controllers
{

[ApiController]
public class MyIdentityController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register([FromBody] Day day)
    {
        // User registration is currently disabled.
        return BadRequest(new { message = "User registration is currently disabled." });
    }
}
}