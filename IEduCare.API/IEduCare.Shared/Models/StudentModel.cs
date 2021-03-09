using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IEduCare.Shared.Models
{
    public class StudentModel
    {
        [Key]
        public Guid Id { get; set; }

        readonly WriteOnce<string> matriculationNo = new WriteOnce<string>();
        [Required]
        public WriteOnce<string> MatriculationNo { get { return matriculationNo; } }

        readonly WriteOnce<string> surname = new WriteOnce<string>();
        [Required]
        public WriteOnce<string> Surname { get { return surname; } }

        readonly WriteOnce<string> firstname = new WriteOnce<string>();
        [Required]
        public WriteOnce<string> Firstname { get { return firstname; } }

        readonly WriteOnce<string> middlename = new WriteOnce<string>();
        [Required]
        public WriteOnce<string> MiddleName { get { return middlename; } }

        readonly WriteOnce<string> maidenName = new WriteOnce<string>();
        [Required]
        public WriteOnce<string> MaidenName { get { return maidenName; } }
        [Required]
        public string Title { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Religion { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Nationality { get; set; }

        [Required]
        public string StateOfOrigin { get; set; }

        [Required]
        public string LocalGovernment { get; set; }

        [Required]
        public string PermanentHomeAddress { get; set; }

        [Required]
        public long TelephoneNo { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Program { get; set; }

        [Required]
        public string NextOfKin { get; set; }

        [Required]
        public string AddressOfNextOfKin { get; set; }

        [Required]
        public long NextOfKinTelephoneNo { get; set; }

        [Required]
        public string NameOfSponsor { get; set; }

        [Required]
        public string SponsorContactAddress { get; set; }

        [Required]
        public long SponsorTelephoneNo { get; set; }

        [Required]
        public string BloodGroup { get; set; }

        [Required]
        public string Genotype { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }
    }

    public sealed class WriteOnce<T>
    {
        private T value;
        private bool hasValue;
        public override string ToString()
        {
            return hasValue ? Convert.ToString(value) : "";
        }
        public T Value
        {
            get
            {
                if (!hasValue) throw new InvalidOperationException("Value has not been set");
                return value;
            }
            set
            {
                if (hasValue) throw new InvalidOperationException("The value has already been set and cannot be altered!");
                this.value = value;
                this.hasValue = true;
            }
        }

        public T ValueOrDefalt { get { return value; } }

        public static implicit operator T(WriteOnce<T> value) { return value.Value}
    }
}
