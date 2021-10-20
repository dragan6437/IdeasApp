using Application;
using Application.Helpers;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.MVC.Helpers;
using Web.MVC.Models;

namespace Web.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly string _token = "token";

        public UsersController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

            if (tokenFromCookie != "" && userId > 0)
                return RedirectToAction("Index", "Ideas");

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel user)
        {
            if (!ModelState.IsValid)
                return View();

            var loggedInUser = _userService.Register(user.MapToUserDTO());
            if(loggedInUser == null)
            {
                return View("CustomError", new CustomErrorViewModel()
                {
                    Title = "Register failed!",
                    Description = $"The username/email is already taken. Please try again with different username/email!"
                });
            }

            Response.SetCookie(_token, loggedInUser.Id);

            return RedirectToAction("Index", "Ideas");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

            if (tokenFromCookie != "" && userId > 0)
                return RedirectToAction("Index", "Ideas");

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel user)
        {
            if (!ModelState.IsValid)
                return View();

            var loggedInUser = _userService.Login(user.MapToUserDTO());
            if (loggedInUser == null)
            {
                return View("CustomError", new CustomErrorViewModel()
                {
                    Title = "Login failed!",
                    Description = $"The username or password you've entered is not correct. Please try again!"
                });
            }

            Response.SetCookie(_token, loggedInUser.Id);

            return RedirectToAction("Index", "Ideas");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(_token);

            return RedirectToAction("Login", "Users");
        }
    }
}
