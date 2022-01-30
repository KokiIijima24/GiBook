using System.Collections.Generic;
using System.Linq;
using GiBook.API.DTOs;
using GiBook.API.Models;
using GiBook.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GiBook.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController
  {
    private readonly 
    ApplicationDbContext _dbContext;
    private readonly ILogger<UserController> _logger;

    public UserController(
        ILogger<UserController> logger
      , ApplicationDbContext dbContext)
    {
      _logger = logger;
      _dbContext = dbContext;
    }

    [HttpGet("list")]
    public IEnumerable<UserDto> GetUsers()
    {
      return _dbContext.Users.Select(_ => 
      new UserDto(){
        Id = _.Id,
        Iamge = null,
        DisplayName = _.UserName
      });
    }
  }
}