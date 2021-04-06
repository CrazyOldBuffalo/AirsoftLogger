using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirsoftLogger.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CMS : Controller
    {
        
    }
}
