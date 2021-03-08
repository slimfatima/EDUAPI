using System;
using System.Collections.Generic;

#nullable disable

namespace IEduCare.Domain.DataModel
{
    public partial class LicenseType
    {
        public LicenseType()
        {
            InstitutionTokens = new HashSet<InstitutionToken>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InstitutionToken> InstitutionTokens { get; set; }
    }
}
