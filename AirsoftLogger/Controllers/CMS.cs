using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirsoftLogger.Models;
using AirsoftLogger.Data;
using Microsoft.Extensions.Logging;

namespace AirsoftLogger.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CMS : Controller
    {

        private readonly DataContext _Context;
        private readonly ILogger<CMS> _logger;
        //private static ViewModel _viewModel;


        public CMS(ILogger<CMS> logger, DataContext Context)
        {
            _Context = Context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult EditSite(string id)
        {
            var editsite = (
                from s in _Context.Sites
                join a in _Context.Addresses
                on s.Postcode equals a.Postcode
                where s.SiteCode == id
                select new SiteForm
                {
                    SiteCode = s.SiteCode,
                    SiteName = s.SiteName,
                    Postcode = s.Postcode,
                    Tel = s.Tel,
                    Website = s.Website,
                    Street = a.Street,
                    City = a.City,

                });
            return View(editsite);
        }

        [HttpGet]
        public IActionResult CreateSite()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }


        [HttpGet]  
        public IActionResult DeleteEvent(int id)
        {
            Events deleteEvent = _Context.Events.Find(id);
            return View(deleteEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(AddEvent addEvent)
        {
            if(ModelState.IsValid)
            {
                Events newEvent = new Events()
                {
                    SiteCode = addEvent.SiteCode,
                    Date = addEvent.Date,
                    Spaces = addEvent.Spaces
                };
                _Context.Events.Add(newEvent);
                _Context.SaveChanges();
                return RedirectToAction("Events", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSite(SiteForm site)
        {
            if (ModelState.IsValid)
            {
                Site editsite = new Site
                {
                    SiteCode = site.SiteCode,
                    SiteName = site.SiteName,
                    Tel = site.Tel,
                    Website = site.Website,
                    Postcode = site.Postcode,
                };
                Address editaddress = new Address
                {
                    Postcode = site.Postcode,
                    Street = site.Street,
                    City = site.City,
                };
                _Context.Sites.Update(editsite);
                _Context.Addresses.Update(editaddress);
                _Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteSite(string id)
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
            foreach(var item in query)
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
            if (modelList.Count != 0)
            {
                return View(modelList);
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEvent(Events Event)
        {
            _Context.Events.Remove(Event);
            _Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSite(SiteDetails siteDetails)
        {
            Site deletesite = new Site
            {
                SiteCode = siteDetails.SiteCode,
                Postcode = siteDetails.Postcode,
                SiteName = siteDetails.SiteName,
                Tel = siteDetails.Tel,
                Website = siteDetails.Website
            };
            Address deleteaddress = new Address
            {
                Postcode = siteDetails.Postcode,
                Street = siteDetails.Street,
                City = siteDetails.City
            };
            _Context.Sites.Remove(deletesite);
            _Context.Addresses.Remove(deleteaddress);
            _Context.SaveChanges();
            return RedirectToAction("Sites", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSite(AddSite addSite)
        {
            if (ModelState.IsValid)
            {
                Site newSite = new Site
                {
                    SiteCode = addSite.SiteCode,
                    Postcode = addSite.Postcode,
                    SiteName = addSite.SiteName,
                    Tel = addSite.Tel,
                    Website = addSite.Website
                };
                Address newAddress = new Address
                {
                    Postcode = addSite.Postcode,
                    Street = addSite.Street,
                    City = addSite.City
                };
                _Context.Sites.Add(newSite);
                _Context.Addresses.Add(newAddress);
                _Context.SaveChanges();
            }
            return RedirectToAction("Sites", "Home");
        }
    }
}
