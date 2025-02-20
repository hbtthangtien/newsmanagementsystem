using Microsoft.AspNetCore.Mvc.Filters;

namespace UI.Filter
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }

    }
}
