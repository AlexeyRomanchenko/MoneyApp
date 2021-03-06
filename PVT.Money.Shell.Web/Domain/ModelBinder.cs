﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using PVT.Money.Shell.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PVT.Money.Shell.Web.Domain
{
    public class ModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult result;

            Type modelType = bindingContext.ModelType;
            object model = Activator.CreateInstance(modelType);
            ICollection <PropertyInfo> properties = modelType.GetProperties();
            foreach (PropertyInfo p in properties)
            {
                result = bindingContext.ValueProvider.GetValue(p.Name);
                p.SetValue(model, result.FirstValue);
            } 


            //SignInModel model = new SignInModel();

            //ValueProviderResult result = bindingContext.ValueProvider.GetValue("Password");
            //model.Password = result.FirstValue;

            //ValueProviderResult login_result = bindingContext.ValueProvider.GetValue("Login");
            //model.Login = login_result.FirstValue;

            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
