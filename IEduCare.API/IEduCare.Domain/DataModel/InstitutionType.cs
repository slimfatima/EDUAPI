using System;
using System.Collections.Generic;

#nullable disable

namespace IEduCare.Domain.DataModel
{
    public partial class InstitutionType
    {
        public InstitutionType()
        {
            Institutions = new HashSet<Institution>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Institution> Institutions { get; set; }
    }
}
