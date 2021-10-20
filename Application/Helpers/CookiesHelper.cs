using Application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class CookiesHelper
    {
        private static readonly IAuthenticationService _authenticationService = new AuthenticationService();

        public static string GetCookie(this HttpRequest request, string key) => request.Cookies[key];

        public static void SetCookie(this HttpResponse response, string key, int userId)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(30);
            response.Cookies.Append(key, _authenticationService.GenerateToken(userId), options);
        }
    }
}
