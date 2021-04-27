using IEduCare.Shared.Dto;
using IEduCare.Shared.Interfaces;
using IEduCare.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEduCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfileController : ControllerBase
    {
        private readonly IStudentProfileManager studentProfile;

        public StudentProfileController(IStudentProfileManager studentProfile)
        {
            this.studentProfile = studentProfile;
        }

        [HttpGet("api/ieducare/studentprofile/getstudentprofile")]
        public ActionResult<IReadOnlyList<StudentProfileDto>> Get()
        {
            var students = studentProfile.GetStudentProfile();
            if (students is null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet("api/ieducare/studentprofile/getstudentprofilebyid", Name = "GetStudentById")]
        public ActionResult<StudentProfileDto> GetStudentById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            var student = studentProfile.GetStudentProfileById(id);
            if (student is null)
            {
                return BadRequest();
            }
            return Ok(student);
        }

        [HttpPost("api/ieducare/studentprofile/createstudentprofile")]
        public ActionResult<StudentProfileDto> CreateStudent([FromBody] StudentProfile model)
        {
            if (model is null)
            {
                return BadRequest();
            }
            var student = studentProfile.CreateStudentProfile(model);
            if (student is null)
            {
                return NotFound();
            }
            return CreatedAtRoute("GetStudentById", new { studentId = student.Id }, student);
        }

        [HttpPut("api/ieducare/studentprofile/updatestudentprofile")]
        public ActionResult<StudentProfileDto> UpdateStudent(Guid id, [FromBody] StudentProfile model)
        {
            if (id == Guid.Empty && model == null)
            {
                return BadRequest();
            }
            var student = studentProfile.UpdateStudentProfile(id, model);
            if (student is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
