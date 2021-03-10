using IEduCare.Shared.Dto;
using IEduCare.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEduCare.API.Controllers
{
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentManager _studentsManager;

        public StudentsController(IStudentManager studentManager)
        {
            _studentsManager = studentManager;
        }

        [HttpGet("api/ieducare/student/get")]
        public ActionResult<List<StudentDto>> Get()
        {
            var students = _studentsManager.GetStudent();
            return students;
        }
    }
}
