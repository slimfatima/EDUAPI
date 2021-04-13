using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Shared.Models
{
    public class DashboardModel
    {
        // Student Information
        public string MatriculationNo { get; set; }
        public string Program { get; set; }
        public byte Level { get; set; }
        public string TypeOfEducation { get; set; }
        public byte NumberOfCourses { get; set; }
        public string Session { get; set; }
        public string Semester { get; set; }

        // Date and login details
        public DateTime LastLogin { get; set; }
        public DateTime Date { get; set; }

        // Courses
        public string CourseListing { get; set; }
        public string Lecturer { get; set; }
        public string LocationOfHall { get; set; }
    }
}
