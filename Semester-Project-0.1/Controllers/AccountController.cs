using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Semester_Project_0._1.Data;
using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using Semester_Project_0._1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IEmailSender _emailSender;

        public AccountController(ApplicationDBContext db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender) 
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            _emailSender = emailSender;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);
                    
                    //below is setting up session storange not sure if I need it but i have it hear for refrence
                    HttpContext.Session.SetString("ssuserName", user.FullName);
                    HttpContext.Session.SetString("ssuserID", user.Id);
                    //var userName = HttpContext.Session.GetString("ssuserName");


                    //return RedirectToAction("Index", "Class");
                    return RedirectToAction("YourAccount", "account");
                }
                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }
        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Instructure));
                await _roleManager.CreateAsync(new IdentityRole(Helper.SystemAdmin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.User));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = model.FirstName +" "+ model.LastName
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleId.ToString());
                    if (!User.IsInRole(Helper.Admin))
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    }
                    else
                    {
                        //need to take this out I think somting on the class index page is using it so I mayneed to rework.
                        TempData["newAdminSignUp"] = user.FullName;
                        TempData["instructerIdTemp"] = user.Id.ToString();
                    }
                    ///////////////////////////////////////////
                    await _emailSender.SendEmailAsync(user.Email, "Account Made For project.class.schedule",
                        $"Your new acount on project.class.schedule have been created.");






                    //////////////////////////////////////////////
                    return RedirectToAction("YourAccount", "Account");
                    //return YourAccount();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }



        public IActionResult YourAccount()
        {
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult ResetPassword()
        {
            //Working hear
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            
            //Working hear
            return View();
        }
    }
}
