using System;
using System.Collections.Generic;

#nullable disable

namespace IEduCare.Domain.DataModel
{
    public partial class Status
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
