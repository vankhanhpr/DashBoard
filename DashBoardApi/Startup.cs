using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassModel.connnection.sql;
using DashBoardApi.quaz.factory;
using DashBoardApi.server.bcs;
using DashBoardApi.server.bcs.impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using ReportSoftWare.model;
using ReportSoftWare.schedule;

namespace DashBoardApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //connect database
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBsc,BscImpl>();
            services.AddScoped<II8MobileApp,I8MobileAppImpl>();
            services.AddScoped<II8MobileAcceptance,I8MobileAcceptanceImpl>();
            services.AddScoped<IDirectory, DirectoryImpl>();
            services.AddScoped<ISlCos, SlCosImpl>();
            services.AddScoped<IDetail_Fiber_MyTV, Detail_Fiber_MyTVImpl>();
            services.AddScoped<IDetailDataReal, DetailDataRealImpl>();

            // Add Quartz services
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            // Add our job
            services.AddSingleton<HelloWorldJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(HelloWorldJob),
                cronExpression: "* * * */2 * ?")); // run every 2 day

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
