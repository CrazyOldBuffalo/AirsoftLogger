using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using AirsoftLogger.Security;
using AirsoftLogger.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace AirsoftLogger.Controllers
{
    public class Security : Controller
    {
        //Username: Admin
        //Password: P@s5W0rd

        //Username: Mod
        //Password: A!rs0ft
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public Security(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Admin obj)
        {
            if (ModelState.IsValid)
            {
                if (!roleManager.RoleExistsAsync("Administrator").Result)
                {
                    AppIdentityRole role = new AppIdentityRole();
                    role.Name = "Administrator";
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }

                AppIdentityUser user = new AppIdentityUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;

                IdentityResult result = userManager.CreateAsync(user, obj.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                    return RedirectToAction("SignIn", "Security");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user Details");
                }
            }
            return View(obj);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Security");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SignIn signIn)
        {
            if(ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(signIn.UserName, signIn.Password, false, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username/Password");
                }
            }
            return View(signIn);
        }


    }
}
