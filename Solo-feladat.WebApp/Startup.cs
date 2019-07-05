using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Solo_feladat.DAL.Context;
using Solo_feladat.Model.Models;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.BLL.Managers;
using Solo_feladat.WebApp.Mapper;
using Hangfire;
using Hangfire.SqlServer;
using Solo_feladat.WebApp.Jobs;
using Solo_feladat.WebApp.PageFilters;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Solo_feladat.WebApp.Jobs.Interfaces;

namespace Solo_feladat.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<SoloContext>(o =>
                o.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddDefaultIdentity<AppUser>()
                    .AddRoles<IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<SoloContext>();

            services.AddTransient<IFlightManager, FlightManager>();

            services.AddTransient<IAirportFileManager, AirportFileManager>();

            services.AddTransient<ILogFileManager, LogFileManager>();

            services.AddTransient<IAirportFileProcessJob, AirportFileProcessJob>();

            services.AddTransient<ILogFileProcessJob, LogFileProcessJob>();

            services.AddSingleton(AutoMapperConfig.Configure());

            services.AddHangfire(configuration => configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        UsePageLocksOnDequeue = true,
                        DisableGlobalLocks = true
                    }));

            services.AddHangfireServer();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExecutionTimePageFilter));
                options.Filters.Add(typeof(SoloExceptionFilter));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAirportFileProcessJob airportFileProcessJob, ILogFileProcessJob logFileProcessJob)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseHangfireDashboard();

            airportFileProcessJob.Execute();
            logFileProcessJob.Execute();

            app.UseMvc();
        }
    }
}
