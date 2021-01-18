using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authorization
{
    public class EmployeeWithMoreYearHandler : AuthorizationHandler<EmployeeWithMoreYearRequirement>
    {
        private readonly IEmployeeNumberOfYears employeeNumberOfYears;
        public EmployeeWithMoreYearHandler(IEmployeeNumberOfYears employeeNumberOfYears)
        {
            this.employeeNumberOfYears = employeeNumberOfYears;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            EmployeeWithMoreYearRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                return Task.CompletedTask;
            }
            var name = context.User.FindFirst(c => c.Type == ClaimTypes.Name);
            var yearsofExperience = employeeNumberOfYears.Get(name.Value);
            if(yearsofExperience >= requirement.Years)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
