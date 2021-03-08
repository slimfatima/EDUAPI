using IEduCare.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Shared.Interfaces
{
    public interface IStudentManager
    {
        List<StudentDto> Get();
        //StudentDto Add(string code, string description);
        //StudentDto Update(Guid id, string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string gender);
    }
}
