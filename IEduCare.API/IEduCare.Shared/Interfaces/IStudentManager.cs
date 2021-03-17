using IEduCare.Shared.Dto;
using IEduCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Shared.Interfaces
{
    public interface IStudentManager
    {
        List<StudentDto> GetStudent();
        StudentDto GetStudentById(Guid id);
        StudentDto CreateStudent(StudentModel model);
        StudentDto UpdateStudent(Guid id, StudentModel model);
        StudentDto DeleteStudent(Guid id);
        
    }
}
