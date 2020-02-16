using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORE_CRUD.Models;
using CORE_CRUD.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CORE_CRUD.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserMgr { get; }
        private SignInManager<AppUser> SignInMgr { get; }

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInMgr.PasswordSignInAsync(model.Email, model.Password,
                    model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Employees");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await UserMgr.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await SignInMgr.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
            }
            return View(model);
        }
    }
}