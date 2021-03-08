using System;
using System.Collections.Generic;

#nullable disable

namespace IEduCare.Domain.DataModel
{
    public partial class Institution
    {
        public Institution()
        {
            ModuleSubscriptions = new HashSet<ModuleSubscription>();
        }

        public Guid Id { get; set; }
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public Guid InstitutionTypeId { get; set; }
        public string InstitutionEmail { get; set; }
        public string PrincipalName { get; set; }
        public string PrincipalPhoneNumber { get; set; }
        public string DefaultAdminId { get; set; }
        public Guid TokenId { get; set; }

        public virtual Address Address { get; set; }
        public virtual AspNetUser DefaultAdmin { get; set; }
        public virtual InstitutionType InstitutionType { get; set; }
        public virtual InstitutionToken Token { get; set; }
        public virtual ICollection<ModuleSubscription> ModuleSubscriptions { get; set; }
    }
}
