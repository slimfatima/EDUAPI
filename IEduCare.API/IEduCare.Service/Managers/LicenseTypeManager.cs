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
    public class LicenseTypeManager : ServiceBase, ILicenseTypeManager
    {
        Repository<LicenseType> _licenseTypeRepository;
        public LicenseTypeManager(string connectionstring, IMapper mapper) : base(connectionstring, mapper)
        {

        }

        public LicenseTypeDto Add(string code, string name)
        {
            var licenceTypeObjDto = new LicenseTypeDto();
            using (var context = new DataContext(ConnectionString))
            {
                _licenseTypeRepository = new Repository<LicenseType>(context);

                var licenceTypeObj = new LicenseType { Code = code, Name = name };
                _licenseTypeRepository.Add(licenceTypeObj);
                _licenseTypeRepository.CommitAndRefreshChanges();

                var mappedObject = Map(licenceTypeObj, licenceTypeObjDto, typeof(LicenseType), typeof(LicenseTypeDto));

                licenceTypeObjDto = mappedObject as LicenseTypeDto;
            }
            return licenceTypeObjDto;
        }

        public List<LicenseTypeDto> Get()
        {
            var dtos = new List<LicenseTypeDto>();
            using (var context = new DataContext(ConnectionString))
            {
                _licenseTypeRepository = new Repository<LicenseType>(context);

                var objs = _licenseTypeRepository.GetAll();

                var mappedObject = Map(objs, dtos, typeof(List<LicenseType>), typeof(List<LicenseTypeDto>));

                dtos = mappedObject as List<LicenseTypeDto>;
            }

            return dtos;
        }

        public LicenseTypeDto Update(Guid id, string code, string name)
        {
            var dto = new LicenseTypeDto();
            using (var context = new DataContext(ConnectionString))
            {
                _licenseTypeRepository = new Repository<LicenseType>(context);

                var _objToUpdate = _licenseTypeRepository.Get(id);
                if(_objToUpdate != null && _objToUpdate.Id != Guid.Empty)
                {
                    _objToUpdate.Code = code;
                    _objToUpdate.Name = name;
                    _licenseTypeRepository.Modify(_objToUpdate);                   

                    var mappedObject = Map(_objToUpdate, dto, typeof(LicenseType), typeof(LicenseTypeDto));

                    dto = mappedObject as LicenseTypeDto;
                    return dto;
                }
                
               
            }

            return null;
        }
    }
}
