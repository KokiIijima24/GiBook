using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiBook.API;
using GiBook.API.Data;
using GiBook.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiBook.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GiBookController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        private readonly ILogger<GiBookController> _logger;

        public GiBookController(
            ILogger<GiBookController> logger,
            ApplicationDbContext context
        )
        {
            _logger = logger;
            _dbcontext = context;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiBook> List()
        {
            return _dbcontext.GiBooks;
        }

        /// <summary>
        /// GiBook会への参加表明
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public bool Regist(GiBook gibook)
        {
            gibook =
                new GiBook()
                {
                    GiBookId = new Guid(),
                    Book = new Book() { Name = "test 001" }
                };
            _dbcontext.GiBooks.Add (gibook);
            return true;
        }
    }
}
