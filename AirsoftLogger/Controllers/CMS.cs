﻿using Microsoft.AspNetCore.Authorization;
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

        public IActionResult EditSite(string SiteCode)
        {
            return View();
        }

        public IActionResult CreateSite()
        {
            return View();
        }
        

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
            if (query.Count != 0)
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
