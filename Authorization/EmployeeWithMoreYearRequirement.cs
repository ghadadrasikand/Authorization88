using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization
{
    public class EmployeeWithMoreYearRequirement:IAuthorizationRequirement
    {
        public EmployeeWithMoreYearRequirement(int years)
        {
            Years = years;
        }
        public int Years { get; }
    }
}
