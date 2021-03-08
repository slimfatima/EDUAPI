using System;
using System.Collections.Generic;

#nullable disable

namespace IEduCare.Domain.DataModel
{
    public partial class Address
    {
        public Address()
        {
            Institutions = new HashSet<Institution>();
        }

        public Guid Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual AspNetUser CreatedByNavigation { get; set; }
        public virtual ICollection<Institution> Institutions { get; set; }
    }
}
