using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gibook.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gibook.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GiBookController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GiBookController> _logger;

        public GiBookController(ILogger<GiBookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get()
        {
            var rng = new Random();
            return 0;
        }
    }
}
