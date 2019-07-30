using FirstSample30.Entities;
using FirstSample30.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public ActionResult<IEnumerable<Professor>> Get()
        {
            var professors = _collegeDbContext.Professors.ToList();

            return Ok(professors);
        }
    }


}