using AutoMapper;
using IEduCare.Domain;
using IEduCare.Domain.Repository;
using IEduCare.Shared.Dto;
using IEduCare.Shared.Interfaces;
using IEduCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Service.Managers
{
    public class StudentProfileManager : ServiceBase, IStudentProfileManager
    {
        Repository<StudentProfile> studentProfileRepo;
        public StudentProfileManager(string connectionstring, IMapper mapper) : base(connectionstring, mapper)
        {

        }

        public IReadOnlyList<StudentProfileDto> GetStudentProfile()
        {
            var dtos = new List<StudentProfileDto>();
            using (var context = new DataContext(ConnectionString))
            {
                studentProfileRepo = new Repository<StudentProfile>(context);

                var objs = studentProfileRepo.GetAll();

                var mappedObject = Map(objs, dtos, typeof(List<StudentProfile>), typeof(List<StudentProfileDto>));

                dtos = mappedObject as List<StudentProfileDto>;
            }

            return dtos;
        }

        public StudentProfileDto GetStudentProfileById(Guid id)
        {
            var dtos = new StudentProfileDto();
            using (var context = new DataContext(ConnectionString))
            {
                studentProfileRepo = new Repository<StudentProfile>(context);

                var objs = studentProfileRepo.Get(id);

                var mappedObject = Map(objs, dtos, typeof(List<StudentProfile>), typeof(List<StudentProfileDto>));

                dtos = mappedObject as StudentProfileDto;
            }

            return dtos;
        }

        public StudentProfileDto CreateStudentProfile(StudentProfile model)
        {
            var studentObjDto = new StudentProfileDto();
            using (var context = new DataContext(ConnectionString))
            {
                studentProfileRepo = new Repository<StudentProfile>(context);

                studentProfileRepo.Add(model);
                studentProfileRepo.CommitAndRefreshChanges();

                var mappedObject = Map(model, studentObjDto, typeof(StudentModel), typeof(StudentDto));

                studentObjDto = mappedObject as StudentProfileDto;
            }
            return studentObjDto;
        }

        public StudentProfileDto UpdateStudentProfile(Guid id, StudentProfile model)
        {
            var dto = new StudentProfileDto();
            using (var context = new DataContext(ConnectionString))
            {
                studentProfileRepo = new Repository<StudentProfile>(context);

                var _objToUpdate = studentProfileRepo.Get(id);
                if (_objToUpdate != null && _objToUpdate.Id != Guid.Empty)
                {
                    // properties of the object to be updated
                    studentProfileRepo.Modify(model);

                    var mappedObject = Map(model, dto, typeof(StudentModel), typeof(StudentDto));

                    dto = mappedObject as StudentProfileDto;
                    return dto;
                }
            }
            return null;
        }
    }
}
