﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using static PVT.Money.Shell.Web.Domain.Container;
using PVT.Money.Shell.Web.Domain;
using PVT.Money.Business;
using React.AspNet;
using PVT.Money.Data;

using PVT.Money.Shell.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace PVT.Money.Shell.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
           
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();


            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "1080630738556-b0qmnhspc2pbk67liln5haovbek0sti1.apps.googleusercontent.com";
                googleOptions.ClientSecret = "2fltjwKyw9-KsrAWTnWxVSo-";
            });

            services.AddMvc();
            services.AddReact();
            

            Container container = new Container();
            container.Add(typeof(Registration));
            container.Add(typeof(Authentication));
            BusinessFaccade.Configuration = Configuration;
            BusinessFaccade.ConfigurationServices(services);
            services.AddSingleton<IContainer, Container>(e=>container);

            services.AddSignalR();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseReact(config => { });
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            app.UseSignalR(routes =>
            routes.MapHub<SomeHub>("SomeChat")
            );
        }
    }
}
