using FirstSample30.Entities;
using FirstSample30.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstSample30.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly CollegeDbContext _collegeDbContext;
        private readonly ILogger<ProfessorsController> _logger;
        private readonly NoSqlDbContext _noSqlDbContext;

        public ProfessorsController(CollegeDbContext collegeDbContext, ILogger<ProfessorsController> logger, NoSqlDbContext noSqlDbContext)
        {
            _collegeDbContext = collegeDbContext;
            _logger = logger;
            _noSqlDbContext = noSqlDbContext;
        }


        //[HttpGet]
        //public ActionResult<IEnumerable<BookListNoSql>> Get()
        //{
        //    var professors = _noSqlDbContext
        //                            .Books
        //                            .AsNoTracking()
        //                            .OrderByDescending(x => x.BookId)
        //                            .ToList();

        //    return Ok(professors);
        //}


        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            var professors = _collegeDbContext
                                .Professors
                                    .AsNoTracking()
                                    .OrderByDescending(x => x.ProfessorId)
                                    .ToList();

            return Ok(professors);
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> GetProfessorById(Guid id)
        {
            var professor = _collegeDbContext
                                .Professors
                                .Where(row => row.ProfessorId == id);

            return Ok(professor);
        }

    }

}