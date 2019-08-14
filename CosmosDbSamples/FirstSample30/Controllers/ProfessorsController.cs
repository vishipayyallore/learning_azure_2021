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