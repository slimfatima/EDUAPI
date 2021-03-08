using IEduCare.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Shared.Interfaces
{
    public interface ILicenseTypeManager
    {
        List<LicenseTypeDto> Get();
        LicenseTypeDto Add(string code, string description);
        LicenseTypeDto Update(Guid id, string code, string description);
    }
}
