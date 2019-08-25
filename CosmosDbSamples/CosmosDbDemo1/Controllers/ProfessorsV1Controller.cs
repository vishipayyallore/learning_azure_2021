using CosmosDbDemo1.Entities;
using CosmosDbDemo1.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosDbDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsV1Controller : ControllerBase
    {

        private readonly ILogger<ProfessorsV1Controller> _logger;
        private readonly CollegeDbContext _collegeDbContext;

        public ProfessorsV1Controller(ILogger<ProfessorsV1Controller> logger, CollegeDbContext collegeDbContext)
        {
            _logger = logger;
            _collegeDbContext = collegeDbContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {


            var newProfessor = new Professor
            {
                ProfessorId = Guid.NewGuid()
            };

            var np = _collegeDbContext.Set<Professor>();
            np.Add(newProfessor);
            _collegeDbContext.Add<Professor>(newProfessor);
            _collegeDbContext.SaveChanges();

            var professors = _collegeDbContext
                                    .Professors
                                    .AsNoTracking()
                                    .OrderByDescending(x => x.ProfessorId)
                                    .ToList();

            return Ok(professors);
        }

    }
}