using System;
using System.Collections.Generic;

#nullable disable

namespace IEduCare.Domain.DataModel
{
    public partial class ModuleSubscription
    {
        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public Guid InstitutionId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Institution Institution { get; set; }
        public virtual Module Module { get; set; }
    }
}
