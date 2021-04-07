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

        [HttpGet]
        public IActionResult Index()
        {
            if (Request.Cookies["DarkMode"] == "True")
            {
                ViewData["Mode"] = Request.Cookies["DarkMode"];
            }
            return View();
        }

        [HttpPost]
        public IActionResult DarkMode()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.UtcNow.AddDays(7);
            options.HttpOnly = true;
            options.Secure = true;
            HttpContext.Response.Cookies.Append("DarkMode", "True", options);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult LightMode()
        {
            HttpContext.Response.Cookies.Delete("DarkMode");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Sites()
        {
            if (Request.Cookies["DarkMode"] == "True")
            {
                ViewData["Mode"] = Request.Cookies["DarkMode"];
            }
            List<Site> Sitemodel = _Context.Sites.ToList();
            return View(Sitemodel);
        }

        [HttpGet]
        public IActionResult SiteDetails(string id)
        {
            if (Request.Cookies["DarkMode"] == "True")
            {
                ViewData["Mode"] = Request.Cookies["DarkMode"];
            }
            List<SiteDetails> modelList = new List<SiteDetails>();
            var query = (from s in _Context.Sites
                         join a in _Context.Addresses
                         on s.Postcode equals a.Postcode
                         join e in _Context.Events
                         on s.SiteCode equals e.SiteCode
                         where s.SiteCode == id
                         select new SiteDetails
                         {
                             SiteCode = s.SiteCode,
                             SiteName = s.SiteName,
                             Website = s.Website,
                             Tel = s.Tel,
                             Street = a.Street,
                             City = a.City,
                             Postcode = a.Postcode,
                             EventID = e.EventID,
                             Date = e.Date,
                             Spaces = e.Spaces
                         }).ToList();
            foreach (var item in query)
            {
                modelList.Add(new SiteDetails()
                {
                    SiteCode = item.SiteCode,
                    SiteName = item.SiteName,
                    Website = item.Website,
                    Tel = item.Tel,
                    Street = item.Street,
                    City = item.City,
                    Postcode = item.Postcode,
                    EventID = item.EventID,
                    Date = item.Date,
                    Spaces = item.Spaces

                });

            }
            if (modelList.Count() != 0)
            {
                return View(modelList);
            }
            else
            {
                var sitequery = (from s in _Context.Sites
                                 join a in _Context.Addresses
                                 on s.Postcode equals a.Postcode
                                 where s.SiteCode == id
                                 select new SiteDetails
                                 {
                                     SiteCode = s.SiteCode,
                                     SiteName = s.SiteName,
                                     Website = s.Website,
                                     Tel = s.Tel,
                                     Street = a.Street,
                                     City = a.City,
                                     Postcode = s.Postcode

                                 }).ToList();
                foreach (var item in sitequery)
                {
                    modelList.Add(new SiteDetails()
                    {
                        SiteCode = item.SiteCode,
                        SiteName = item.SiteName,
                        Website = item.Website,
                        Tel = item.Tel,
                        Street = item.Street,
                        City = item.City,
                        Postcode = item.Postcode
                    });
                }
                return View(modelList);
            }
        }

        [HttpGet]
        public IActionResult SearchSite(String SearchString)
        {
            if (Request.Cookies["DarkMode"] == "True")
            {
                ViewData["Mode"] = Request.Cookies["DarkMode"];
            }
            var sites = from s in _Context.Sites
                        select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                sites = sites.Where(s => s.SiteName.Contains(SearchString) || s.Postcode.Contains(SearchString) || s.SiteCode.Contains(SearchString));
                List<Site> searchSites = sites.ToList();
                if (searchSites.Count == 0)
                {
                    List<Site> sitemodel = _Context.Sites.ToList();
                    return View("Sites", sitemodel);
                }
                else { 
                    return View("Sites", searchSites); 
                }
                
            }
            else
            {
                List<Site> sitemodel = _Context.Sites.ToList();
                return View("Sites", sitemodel);
            }
        }

        [HttpGet]
        public IActionResult SearchEvent(String SearchString)
        {
            if (Request.Cookies["DarkMode"] == "True")
            {
                ViewData["Mode"] = Request.Cookies["DarkMode"];
            }
            var events = from e in _Context.Events
                         select e;
            if(!String.IsNullOrEmpty(SearchString))
            {
                events = events.Where(e => e.SiteCode.Contains(SearchString));
                List<Events> searchEvents = events.ToList();
                if (searchEvents.Count == 0)
                {
                    List<Events> EventModel = events.ToList();
                    return View("Events", EventModel);

                }
                return View("Events", searchEvents);
            }
            else
            {
                List<Events> EventModel = _Context.Events.ToList();
                return View("Events", EventModel);
            }
                         
        }

        [HttpGet]
        public IActionResult Events()
        {
            if (Request.Cookies["DarkMode"] == "True")
            {
                ViewData["Mode"] = Request.Cookies["DarkMode"];
            }
            List<Events> eventlist = _Context.Events.ToList();
            return View(eventlist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateEvents(SiteDetails siteDetails)
        {
            Events eventUpdate = new Events
            {
                EventID = siteDetails.EventID,
                SiteCode = siteDetails.SiteCode,
                Date = siteDetails.Date,
                Spaces = siteDetails.Spaces - 1
            };
            _Context.Events.Update(eventUpdate);
            _Context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }   
}
