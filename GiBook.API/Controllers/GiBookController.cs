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
    [Route("api/[controller]")]
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
        [HttpGet("list")]
        public IEnumerable<GiBook> List()
        {
            return _dbcontext.GiBooks;
        }

        /// <summary>
        /// GiBook会への参加表明
        /// ＞書籍名の登録
        /// </summary>
        /// <returns></returns>
        [HttpPost("regist")]
        public async Task<bool> RegistAsync(GiBook gibook)
        {
            var locationId = Guid.NewGuid();

            gibook =
                new GiBook()
                {
                    GiBookId = new Guid(),
                    GiverId = "841dfcf7-b78e-44da-a550-6a3363f6bb8b",
                    RecieverId = "6001c6f4-f309-4d0c-ad72-fed26fa41311",
                    // BookId = new Guid(),
                    LocationId =
                        new Guid("570a07ad-bb94-4471-8071-56accbb9e8f2")
                };

            var location =
                new Location() { LocationId = locationId, Name = "TEST" };

            // _dbcontext.Books.Add(gibook.Book);
            _dbcontext.Locations.Add (location);
            _dbcontext.GiBooks.Add (gibook);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
