using System.Collections.Generic;
using API.Extensions;
using API.Middleware;
using Application.Core;
using Application.Events;
using Domain;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API
{
  public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // added fluent validation to validate some fields
            services.AddControllers().AddFluentValidation(config =>
            {
                // only need to add one handler class for fluent validation to catch all (hopefully)
                config.RegisterValidatorsFromAssemblyContaining<CreateReport>();
            });
            services.AddApplicationServices(_config);
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    // Cors policy whitelisting React client application
                    policy.AllowAnyMethod().AllowAnyHeader()
                        .WithOrigins("http://localhost:3000", "https://localhost:5001", "https://video-lax3-1.xx.fbcdn.net");
                });
            });
            // adding identity roles
            // creates about six DB tables just from adding this code (users, roles, etc.)
            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MeekinFirewatchContext>();
            services.AddAuthentication();
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // at some of waterfall gets executed, catching any exceptions and returning the response
            app.UseMiddleware<ExceptionMiddleware>();
            
            if (env.IsDevelopment())
            {
                // using our own exception handler instead of dev exception page
                // app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            // app.UseHttpsRedirection();

            app.UseRouting();
            // add CORS, make sure it's in this order, after routing
            app.UseCors(opt =>
            {
                // add local React host
                opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
