using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IEduCare.Shared.Models
{
    public class LicenseTypeModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
