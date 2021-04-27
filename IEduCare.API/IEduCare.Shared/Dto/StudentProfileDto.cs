using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Shared.Dto
{
    public class StudentProfileDto
    {
        // student profile
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string MatriculationNo { get; set; }
        public string CourseOfStudy { get; set; }
        public string Department { get; set; }
        public string Faculty { get; set; }
        public string CurrentLevel { get; set; }

        // Biodata
    }
}
