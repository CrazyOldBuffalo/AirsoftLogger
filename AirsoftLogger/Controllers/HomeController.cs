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
            if (query.Count() != 0)
            {
                return View(query);
            }
            else
            {
                List<SiteDetails> siteDetails = new List<SiteDetails>();
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
                return View(sitequery);
            }
        }

        public IActionResult Search(String SearchString)
        {
            var sites = from s in _Context.Sites
                        select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                sites = sites.Where(s => s.SiteName.Contains(SearchString) || s.Postcode.Contains(SearchString));
                List<Site> searchSites = sites.ToList();
                return View("Sites", searchSites);
            }
            else
            {
                List<Site> sitemodel = _Context.Sites.ToList();
                return View("Sites", sitemodel);
            }
        }

        public IActionResult Events()
        {
            List<Events> eventlist = _Context.Events.ToList();
            return View(eventlist);
        }

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
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }   
}
