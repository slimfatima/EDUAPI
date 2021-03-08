using AutoMapper;
using IEduCare.Domain;
using IEduCare.Domain.DataModel;
using IEduCare.Domain.Repository;
using IEduCare.Shared.Dto;
using IEduCare.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Service.Managers
{
    public class StudentManager : ServiceBase, IStudentManager
    {
        Repository<Student> _studentRepository;
        public StudentManager(string connectionstring, IMapper mapper) : base(connectionstring, mapper)
        {

        }

        public List<StudentDto> Get()
        {
            var dtos = new List<StudentDto>();
            using (var context = new DataContext(ConnectionString))
            {
                _studentRepository = new Repository<Student>(context);

                var objs = _studentRepository.GetAll();

                var mappedObject = Map(objs, dtos, typeof(List<Student>), typeof(List<StudentDto>));

                dtos = mappedObject as List<StudentDto>;
            }

            return dtos;
        }
    }
}
