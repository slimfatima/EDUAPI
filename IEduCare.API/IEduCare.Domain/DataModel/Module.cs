using System;
using System.Collections.Generic;

#nullable disable

namespace IEduCare.Domain.DataModel
{
    public partial class Module
    {
        public Module()
        {
            ModuleSubscriptions = new HashSet<ModuleSubscription>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ModuleSubscription> ModuleSubscriptions { get; set; }
    }
}
