﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using erdus.ng.Helpers;
using erdus.ng.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using erdus.ng.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using erdus.ng.Models;
using erdus.ng.Repositories;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Events;
using System;

namespace erdus.ng
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
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<MultilanguageIdentityErrorDescriber>();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddOptions();
            services.Configure<SmtpSettings>(Configuration.GetSection("MailSettings"));

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRequestsService, RequestsService>();
            services.AddScoped<IStatusesService, StatusesService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDatabaseRepository, DatabaseRepository>();
            services.AddScoped<IFTPRepository, FTPRepository>();
            services.AddScoped<ISendMessageRepository, SendMailRepository>();
            services.AddScoped<IMailTemplateResolverRepository, MailTemplateResolverRepository>();
            services.AddScoped<ISendMessageService, SendMessageService>();


            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(Configuration["Logging:Path"], rollingInterval: RollingInterval.Hour)
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }

}
