using AutoMapper;
using IEduCare.Domain;
using IEduCare.Domain.DataModel;
using IEduCare.Domain.Repository;
using IEduCare.Shared.Dto;
using IEduCare.Shared.Interfaces;
using IEduCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Service.Managers
{
    public class StudentManager : ServiceBase, IStudentManager
    {
        Repository<StudentModel> _studentRepository;
        public StudentManager(string connectionstring, IMapper mapper) : base(connectionstring, mapper)
        {

        }

        public List<StudentDto> GetStudent()
        {
            var dtos = new List<StudentDto>();
            using (var context = new DataContext(ConnectionString))
            {
                _studentRepository = new Repository<StudentModel>(context);

                var objs = _studentRepository.GetAll();

                var mappedObject = Map(objs, dtos, typeof(List<Student>), typeof(List<StudentDto>));

                dtos = mappedObject as List<StudentDto>;
            }

            return dtos;
        }

        public StudentDto GetStudentById(Guid id)
        {
            var dtos = new StudentDto();
            using (var context = new DataContext(ConnectionString))
            {
                _studentRepository = new Repository<StudentModel>(context);

                var objs = _studentRepository.Get(id);

                var mappedObject = Map(objs, dtos, typeof(List<StudentModel>), typeof(List<StudentDto>));

                dtos = mappedObject as StudentDto;
            }

            return dtos;
        }

        public StudentDto CreateStudent(StudentModel model)
        {
            var studentObjDto = new StudentDto();
            using (var context = new DataContext(ConnectionString))
            {
                _studentRepository = new Repository<StudentModel>(context);

                var studentObj = new StudentModel
                {
                    // add all the student model properties
                };
                _studentRepository.Add(studentObj);
                _studentRepository.CommitAndRefreshChanges();

                var mappedObject = Map(studentObj, studentObjDto, typeof(StudentModel), typeof(StudentDto));

                studentObjDto = mappedObject as StudentDto;
            }
            return studentObjDto;
        }

        public StudentDto UpdateStudent(Guid id, StudentModel model)
        {
            var dto = new StudentDto();
            using (var context = new DataContext(ConnectionString))
            {
                _studentRepository = new Repository<StudentModel>(context);

                var _objToUpdate = _studentRepository.Get(id);
                if (_objToUpdate != null && _objToUpdate.Id != Guid.Empty)
                {
                    // properties of the object to be updated
                    _studentRepository.Modify(_objToUpdate);

                    var mappedObject = Map(_objToUpdate, dto, typeof(StudentModel), typeof(StudentDto));

                    dto = mappedObject as StudentDto;
                    return dto;
                }
            }
            return null;
        }

        public StudentDto DeleteStudent(Guid id)
        {
            var dto = new StudentDto();
            using (var context = new DataContext(ConnectionString))
            {
                _studentRepository = new Repository<StudentModel>(context);

                var _objToUpdate = _studentRepository.Get(id);
                if (_objToUpdate != null && _objToUpdate.Id != Guid.Empty)
                {
                    // properties of the object to be updated
                    _studentRepository.Remove(_objToUpdate);

                    var mappedObject = Map(_objToUpdate, dto, typeof(StudentModel), typeof(StudentDto));

                    dto = mappedObject as StudentDto;
                    return dto;
                }
            }
            return null;
        }
    }
}
