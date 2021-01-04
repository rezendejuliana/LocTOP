using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == (byte)MembershipType.Unknown 
                || customer.MembershipTypeId == (byte) MembershipType.InitialPlan) //0 é padrao´default entao é quando n selecionou nada, e 1 é o primeiro da lista
            {
               return ValidationResult.Success;
            }
            if(customer.BirthDate == null)
            {
              return new ValidationResult("Birthdate is required.");
            }

           var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
  
           return (age >= 18)
                ? ValidationResult.Success
               : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }

    }
}