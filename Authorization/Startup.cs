using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var key = "This is my test key";
            services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>
                ("Basic", null);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAndPowerUser", policy =>
                 policy.RequireRole("Administrator", "Poweruser"));
                options.AddPolicy("EmployeeWithMoreThan20Years",policy=>
                policy.Requirements.Add(new EmployeeWithMoreYearRequirement(20))
                );
            });
            services.AddSingleton<IAuthorizationHandler, EmployeeWithMoreYearHandler>();
            services.AddSingleton<IEmployeeNumberOfYears, EmployeeNumberOfYears>();
            services.AddSingleton<ICustomAuthenticationManager,CustomAuthenticationManager>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "api/"
                //defaults: new { controller = "Product", action = "Message", }
                );
            });
        }
    }
}
