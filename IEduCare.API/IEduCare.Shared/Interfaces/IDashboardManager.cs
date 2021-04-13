using IEduCare.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEduCare.Shared.Interfaces
{
    public interface IDashboardManager
    {
        IReadOnlyList<DashboardDto> GetStudent();
        DashboardDto GetStudentById(Guid id);
    }
}
