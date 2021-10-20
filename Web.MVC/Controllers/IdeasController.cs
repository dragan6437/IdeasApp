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
    public class IdeasController : Controller
    {
        private readonly IIdeaService _ideaService;
        private readonly IAuthenticationService _authenticationService;
        private readonly string _token = "token";

        public IdeasController(IIdeaService ideaService, IAuthenticationService authenticationService)
        {
            _ideaService = ideaService;
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);
            if (userId <= 0)
                return RedirectToAction("Login", "Users");

            var model = _ideaService.GetIdeas().MapToIdeaVm();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);
            if (userId <= 0)
                return RedirectToAction("Login", "Users");

            return View();
        }

        [HttpPost]
        public IActionResult Add(AddIdeaViewModel idea)
        {
            if (!ModelState.IsValid)
                return View();

            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

            var ideaDTO = idea.MapToIdeaDTO();
            ideaDTO.UserId = userId;

            var result = _ideaService.Add(ideaDTO);
            if (result)
                return RedirectToAction("Index");

            return View("CustomError", new CustomErrorViewModel()
            {
                Title = "Added failed",
                Description = $"Failed to add an idea. Please check the entered data and try again."
            });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);
            if (userId <= 0)
                return RedirectToAction("Login", "Users");

            var model = _ideaService.GetIdea(id);
            if (model == null || model.UserId != userId)
            {
                return View("CustomError", new CustomErrorViewModel()
                {
                    Title = "Delete failed!",
                    Description = $"The idea doesn't exists, or you are not authorized to delete this idea!"
                });
            }

            return View("Delete", model.MapToIdeaVm());
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var result = _ideaService.Delete(id);
            if (result)
                return RedirectToAction("Index");

            return View("CustomError", new CustomErrorViewModel()
            {
                Title = "Delete failed!",
                Description = $"Failed to delete the idea with Id: {id}."
            });
        }
    }
}
