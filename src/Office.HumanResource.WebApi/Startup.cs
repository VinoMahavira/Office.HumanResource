using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Office.HumanResource.Core.Interfaces;
using Office.HumanResource.Core.Shared;
using Office.HumanResource.Infrastructure.Data;
using Office.HumanResource.WebApi.Models;
using StructureMap;

namespace Office.HumanResource.WebApi
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql("Server=localhost;Database=HumanResource;User=root;Password=root;")
            );

            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var container = new Container();

            container.Configure(config => 
            {
                config.Scan(_ => {
                    _.AssemblyContainingType(typeof(Startup));
                    _.AssemblyContainingType(typeof(BaseEntity));
                    _.Assembly("Office.HumanResource.Infrastructure");
                    _.WithDefaultConventions();
                });

                config.For(typeof(IRepository<>)).Add(typeof(EfRepository<>));
                
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
