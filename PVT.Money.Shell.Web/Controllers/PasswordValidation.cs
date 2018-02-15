using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PVT.Money.Shell.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PVT.Money.Shell.Web.Controllers
{
    public class BtmLineAttribute : ValidationAttribute
    {
        private string _string;

        public BtmLineAttribute()
        {
           // _string = Str;
        }

       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            SignInModel model = (SignInModel)validationContext.ObjectInstance;
            int index = model.Password.IndexOf("_");
            if (index!=-1)
            {
                return ValidationResult.Success;
                
            }

            return new ValidationResult(ErrorMessage);
        }


    }
}
