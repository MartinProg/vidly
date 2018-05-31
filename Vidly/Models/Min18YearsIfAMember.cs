using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Models
{
    public class Min18YearsIfAMember :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            /*
             * Not prefered to use "Magic Numbers" like ==1, ==0 for code maintainability, 
               Suggested Solutions: to use static field in class of MembershipType like
               public static readonly byte Unknown=0;
               public static readonly byte PayAsYouGo=1;
            */
            //Another Solution could be
            //if (customer.MembershipType==null || customer.MembershipType.Name=="Pay As You Go")
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (customer.birthdate == null)
                return new ValidationResult ( "Birth Date is Required" );

            var age = DateTime.Today.Year - customer.birthdate.Value.Year;
            return age > 18 ?
                ValidationResult.Success :
                new ValidationResult("Member Should be above 18 Years");
        }
    }
}