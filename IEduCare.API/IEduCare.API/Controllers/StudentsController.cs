using IEduCare.Shared.Dto;
using IEduCare.Shared.Interfaces;
using IEduCare.Shared.Models;
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
            if (students is null)
            {
                return NotFound();
            }
            return students;
        }

        [HttpGet("api/ieducare/student/getstudentbyid")]
        public ActionResult<StudentDto> GetStudentById(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }
            var student = _studentsManager.GetStudentById(id);
            if(student is null)
            {
                return BadRequest();
            }
            return student;
        }

        [HttpPost("api/ieducare/student/createstudent")]
        public ActionResult<StudentDto> CreateStudent([FromBody] StudentModel model)
        {
            if(model is null)
            {
                return BadRequest();
            }
            var student = _studentsManager.CreateStudent(model);
            if(student is null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPut("api/ieducare/student/updatestudent")]
        public ActionResult<StudentDto> UpdateStudent(Guid id, [FromBody] StudentModel model)
        {
            if(id == Guid.Empty && model == null)
            {
                return BadRequest();
            }
            var student = _studentsManager.UpdateStudent(id, model);
            if(student is null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpDelete("api/ieducare/student/deletestudent")]
        public ActionResult<StudentDto> DeleteStudent(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }
            return _studentsManager.DeleteStudent(id);
        }
    }
}
