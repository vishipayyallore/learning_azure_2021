using CosmosDbDemo1.Entities;
using CosmosDbDemo1.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CosmosDbDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookListNoSqlController : ControllerBase
    {

        private readonly ILogger<BookListNoSqlController> _logger;
        private readonly NoSqlDbContext _noSqlDbContext;

        public BookListNoSqlController(ILogger<BookListNoSqlController> logger, NoSqlDbContext noSqlDbContext)
        {
            _logger = logger;
            _noSqlDbContext = noSqlDbContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<BookListNoSql>> Get()
        {
            var books = _noSqlDbContext
                                    .Books
                                    .AsNoTracking()
                                    .OrderByDescending(x => x.BookId)
                                    .ToList();

            return Ok(books);
        }

    }
}