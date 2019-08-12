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

        public ProfessorsController(CollegeDbContext collegeDbContext, ILogger<ProfessorsController> logger)
        {
            _collegeDbContext = collegeDbContext;
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<Professor> Get()
        {
            DbContextOptionsBuilder<CollegeDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<CollegeDbContext>();

            dbContextOptionsBuilder.UseCosmos(
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                "webapidemodb");

            using (var collegeDbContext = new CollegeDbContext(dbContextOptionsBuilder.Options))
            {
                var professor = _collegeDbContext
                                .Professors
                                .FirstOrDefault();
            }

            var professors = _collegeDbContext
                                .Professors
                                .FirstOrDefault();
                                

            return Ok(professors);
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> GetProfessorById(Guid id)
        {
            var professor = _collegeDbContext
                                .Professors
                                .Where(row => row.ProfessorId == id)
                                .Include(row => row.Students);

            return Ok(professor);
        }

    }

}