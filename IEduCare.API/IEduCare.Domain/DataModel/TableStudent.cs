using System;
using System.Collections.Generic;

#nullable disable

namespace IEduCare.Domain.DataModel
{
    public partial class TableStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public int PhoneNumber { get; set; }
        public int Id { get; set; }
    }
}
