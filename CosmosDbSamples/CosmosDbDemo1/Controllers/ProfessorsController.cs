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
    public class ProfessorsController : ControllerBase
    {

        private readonly ILogger<ProfessorsController> _logger;
        private readonly NoSqlDbContext _noSqlDbContext;

        public ProfessorsController(ILogger<ProfessorsController> logger, NoSqlDbContext noSqlDbContext)
        {
            _logger = logger;
            _noSqlDbContext = noSqlDbContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<BookListNoSql>> Get()
        {
            var professors = _noSqlDbContext
                                    .Books
                                    .AsNoTracking()
                                    .OrderByDescending(x => x.BookId)
                                    .ToList();

            return Ok(professors);
        }

    }
}