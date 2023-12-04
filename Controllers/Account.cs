﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ally.Constants;
using ally.Services;
using ally.ViewModels;
using System.Threading.Tasks;
using ally.Models;

namespace ally.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(model.Login);
            if (user == null) user = await _userManager.FindByEmailAsync(model.Login);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            }

            if (!user.isActive)
            {
                ModelState.AddModelError("", "You are blocked");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Register()
        {
            return View();
            //return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                ModelState.AddModelError("Username", "There is already user with this username");
                return View();
            }

            User newUser = new User
            {
                Fullname = model.Fullname,
                Email = model.Email,
                UserName = model.Username,
                EmailConfirmed = true,
            };

            IdentityResult idtResult = await _userManager.CreateAsync(newUser, model.Password);

            if (!idtResult.Succeeded)
            {
                foreach (var error in idtResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(newUser, RoleConstants.User);

            return RedirectToAction("Index", "Home");

        }
    }
}
