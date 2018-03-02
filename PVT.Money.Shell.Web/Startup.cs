using System;
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

namespace PVT.Money.Shell.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string connString = Configuration.GetConnectionString("database");

            BusinessFaccade businessFaccade = new BusinessFaccade();
            businessFaccade.UseDataFaccade(connString);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddAuthentication("MyAuth").AddCookie("MyAuth", options =>
            {
                options.AccessDeniedPath = new PathString("/");
                options.LoginPath = new PathString("/Account/login");
            }         
           );
            Container container = new Container();
            container.Add(typeof(Registration));
            container.Add(typeof(Authentication));
            services.AddSingleton<IContainer, Container>(e=>container);

        
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

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
