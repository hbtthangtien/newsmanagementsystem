using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Security.Principal;
using System.Text.Json;
using System.Web;
using UI.Models;
namespace UI.Filter
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;
        private readonly string[] _customRoles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
            _customRoles = ["admin", "staff", "", ""];
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<CustomAuthorizeAttribute>>();
            logger.LogInformation("Starting authorization check.");

            var userJson = context.HttpContext.Session.GetString("user");
            if (userJson == null)
            {
                logger.LogInformation("No user session found. Redirecting to login.");
                context.Result = new RedirectToActionResult("Index", "Login", new {area=""});
            }
            else
            {
                var user = JsonSerializer.Deserialize<UserModel>(userJson);
                if (!_roles.Any(role => string.Equals(user.Role.ToString(), role, StringComparison.OrdinalIgnoreCase)))
                {
                    logger.LogInformation($"User role {user.Role} is not authorized. Redirecting to access denied.");
                    context.Result = new RedirectToActionResult("Index", "Login", new { area = "" });
                }
                else
                {
                    logger.LogInformation("User is authorized. Proceeding with request.");
                }
            }
        }

    }
}
