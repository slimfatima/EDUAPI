using IEduCare.Shared.Dto;
using IEduCare.Shared.Interfaces;
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
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardManager dashboardManager;

        public DashboardController(IDashboardManager dashboardManager)
        {
            this.dashboardManager = dashboardManager;
        }

        [HttpGet("api/ieducare/dashboard/get")]
        public ActionResult<IReadOnlyList<DashboardDto>> Get()
        {
            var students = dashboardManager.GetStudent();
            if (students is null)
            {
                return NotFound();
            }
            return (ActionResult)students;
        }

        [HttpGet("api/ieducare/dashboard/getstudentbyid")]
        public ActionResult<DashboardDto> GetStudentById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            var student = dashboardManager.GetStudentById(id);
            if (student is null)
            {
                return BadRequest();
            }
            return student;
        }
    }
}
