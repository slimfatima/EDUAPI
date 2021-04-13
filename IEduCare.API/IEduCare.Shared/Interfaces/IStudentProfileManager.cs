using IEduCare.Shared.Dto;
using IEduCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Shared.Interfaces
{
    public interface IStudentProfileManager
    {
        IReadOnlyList<StudentProfileDto> GetStudentProfile();
        StudentProfileDto GetStudentProfileById(Guid id);
        StudentProfileDto CreateStudentProfile(StudentProfile model);
        StudentProfileDto UpdateStudentProfile(Guid id, StudentProfile model);
    }
}
