using AirsoftLogger.Data;
using AirsoftLogger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AirsoftLogger.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataContext _Context;
        private readonly ILogger<HomeController> _logger;
        //private static ViewModel _viewModel;


        public HomeController(ILogger<HomeController> logger, DataContext Context)
        {
            _Context = Context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            options.HttpOnly = true;
            options.Secure = true;
            HttpContext.Response.Cookies.Append("DarkMode", "false", options);
            return View();
        }

        public IActionResult Sites()
        {
            List<Site> Sitemodel = _Context.Sites.ToList();
            return View(Sitemodel);
        }

        public IActionResult SiteDetails(string id)
        {
            Site SiteDetails = _Context.Sites.Find(id);
            return View(SiteDetails);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }   
}
