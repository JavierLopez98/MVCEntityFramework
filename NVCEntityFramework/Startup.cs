using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NVCEntityFramework.Data;
using NVCEntityFramework.Models;
using NVCEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940


        
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = Configuration.GetConnectionString("casasqlhospital");

            services.AddTransient<RepositoryPlantilla>();
            services.AddTransient<RepositoryHospital>();
            services.AddTransient<RepositoryDoctores>();
            services.AddTransient<RepositoryEmpleadosHospital>();
            services.AddDbContext<HospitalContext>(options => options.UseSqlServer(cadena));

            services.AddTransient<RepositoryEnfermos>();
            services.AddDbContext<EnfermosContext>(options => options.UseSqlServer(cadena));

            services.AddTransient<RepositoryEmpleados>();
            services.AddDbContext<EmpleadoContext>(options => options.UseSqlServer(cadena));

            services.AddTransient<RepositoryTodosEmpleados>();
            services.AddDbContext<TodosEmpleadosContext>(options => options.UseSqlServer(cadena));


            //String cadena = "Data Source=LOCALHOST;Initial Catalog=Hospital;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            //services.AddSingleton<IDepartamentosContext>(context => new DepartamentosContextMySql(cadena));
            //services.AddSingleton<IDepartamentosContext>(context=>new DepartamentosContextSQL(cadena));
            //services.AddTransient<Coche>();
            services.AddControllersWithViews();
            //services.AddSingleton<ICoche, Deportivo>();
           // services.AddSingleton<ICoche>(z=> new Deportivo("marca1","modelo1","1.jpg",230));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                        name:"default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
