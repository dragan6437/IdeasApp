using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.MVC.Models;

namespace Web.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("CustomError")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var model = new CustomErrorViewModel()
            {
                Title = "Unexpected Server Error",
                Description = exceptionDetails.Error.Message
            };

            return View("CustomError", model);
        }

        [Route("CustomError/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            var model = new CustomErrorViewModel()
            {
                Title = "Server Error",
                Description = $"The Server responded with status code {statusCode}"
            };
            return View("CustomError", model);
        }
    }
}
