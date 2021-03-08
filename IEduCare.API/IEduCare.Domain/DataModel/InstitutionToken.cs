using System;
using System.Collections.Generic;

#nullable disable

namespace IEduCare.Domain.DataModel
{
    public partial class InstitutionToken
    {
        public InstitutionToken()
        {
            Institutions = new HashSet<Institution>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public Guid LicenceTypeId { get; set; }

        public virtual LicenseType LicenceType { get; set; }
        public virtual ICollection<Institution> Institutions { get; set; }
    }
}
