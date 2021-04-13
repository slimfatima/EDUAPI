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
    public class DashboardManager : ServiceBase, IDashboardManager
    {
        Repository<DashboardModel> dashboardRepo;
        public DashboardManager(string connectionstring, IMapper mapper) : base(connectionstring, mapper)
        {

        }
        public IReadOnlyList<DashboardDto> GetStudent()
        {
            var dtos = new List<DashboardDto>();
            using (var context = new DataContext(ConnectionString))
            {
                dashboardRepo = new Repository<DashboardModel>(context);

                var objs = dashboardRepo.GetAll();

                var mappedObject = Map(objs, dtos, typeof(List<DashboardModel>), typeof(List<DashboardDto>));

                dtos = mappedObject as List<DashboardDto>;
            }

            return dtos;
        }

        public DashboardDto GetStudentById(Guid id)
        {
            var dtos = new DashboardDto();
            using (var context = new DataContext(ConnectionString))
            {
                dashboardRepo = new Repository<DashboardModel>(context);

                var objs = dashboardRepo.Get(id);

                var mappedObject = Map(objs, dtos, typeof(List<DashboardModel>), typeof(List<DashboardDto>));

                dtos = mappedObject as DashboardDto;
            }

            return dtos;
        }
    }
}
