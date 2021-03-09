
using AutoMapper;
using IEduCare.Domain.DataModel;
using IEduCare.Shared.Dto;
using IEduCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Service
{
    public class ServiceMapProfile : AutoMapper.Profile
    {
        public ServiceMapProfile()
        {          

            CreateMap<LicenseType, LicenseTypeDto>();
            CreateMap<StudentModel, StudentDto>();
           
        }
    }
}
