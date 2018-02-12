using Microsoft.AspNetCore.Mvc.ModelBinding;
using PVT.Money.Shell.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVT.Money.Shell.Web.Domain
{
    public class ModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            SignInModel model = new SignInModel();

            ValueProviderResult result = bindingContext.ValueProvider.GetValue("Password");
            model.Password = result.FirstValue;

            ValueProviderResult login_result = bindingContext.ValueProvider.GetValue("Login");
            model.Login = login_result.FirstValue;

            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
