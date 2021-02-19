//using FirstSample30.Entities;
//using FirstSample30.Persistence;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Linq;

//namespace FirstSample30.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentsController : ControllerBase
//    {
//        private readonly CollegeDbContext _collegeDbContext;
//        private readonly ILogger<StudentsController> _logger;

//        public StudentsController(CollegeDbContext collegeDbContext, ILogger<StudentsController> logger)
//        {
//            _collegeDbContext = collegeDbContext;

//            _logger = logger;
//        }


//        [HttpGet]
//        public ActionResult<IEnumerable<Student>> Get()
//        {
//            var students = _collegeDbContext
//                                .Students
//                                .ToList();

//            return Ok(students);
//        }

//    }

//}