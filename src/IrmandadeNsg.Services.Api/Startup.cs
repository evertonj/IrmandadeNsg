using IrmandadeNsg.Services.Api.Configurations;
using IrmandadeNsg.Infra.CrossCutting.Identity.Authorization;
using IrmandadeNsg.Infra.CrossCutting.Identity.Data;
using IrmandadeNsg.Infra.CrossCutting.Identity.Models;
using IrmandadeNsg.Infra.CrossCutting.IoC;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace IrmandadeNsg.Services.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapperSetup();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWritePostData", policy => policy.Requirements.Add(new ClaimRequirement("Posts", "Write")));
                options.AddPolicy("CanRemovePostData", policy => policy.Requirements.Add(new ClaimRequirement("Posts", "Remove")));
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "IrmandadeNsg Project",
                    Description = "IrmandadeNsg API Swagger surface",
                    Contact = new Contact { Name = "Everton Spindola", Email = "evertonspindola@gmail.com" },
                });
            });

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint($"/swagger/v1/swagger.json", "IrmandadeNsg Project API v1.1");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
