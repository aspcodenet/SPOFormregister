using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormRegister.ViewModels
{

    public class CheckPersonNummer : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string personnummer = Convert.ToString(value);
            DateTime dt;
            if (personnummer.Length == 10 || personnummer.Length == 11)
            {
                if (!DateTime.TryParseExact(personnummer.Substring(0, 6), "yyMMdd", null, System.Globalization.DateTimeStyles.AssumeLocal, out dt))
                {
                    return new ValidationResult("felaktigt personnummer");
                }
            }
            else
            {
                if (!DateTime.TryParseExact(personnummer.Substring(0, 8), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AssumeLocal, out dt))
                {
                    return new ValidationResult("felaktigt personnummer");
                }
            }
            return ValidationResult.Success;


        }

    }


    public class RegisterViewModel
    {
        public bool RegistrationError { get; set; }
        public bool Saved { get; set; }

        [Required(ErrorMessage ="Förnamn är ju obligartiskt dumsnut")]
        public string Forname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [MinLength(4)]
        public string Loginname { get; set; }

        [DataType(DataType.Date)]
        public DateTime MedlemsDatum { get; set; }

        [RegularExpression(@"^(\d{6}|\d{8})[-|(\s)]{0,1}\d{4}$",ErrorMessage ="Felaktigt personnummer")]
        [CheckPersonNummer]
        public string PersonNummer { get; set; } 
 
        [Range(1000,9999)]
        public int Pincode { get; set; }
        public string CountryCode { get; set; }
    }
}