using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirsoftLogger.Security
{
    public class AppIdentityUser : IdentityUser
    {
        public string RoleDescription { get; set; }
    }
}
