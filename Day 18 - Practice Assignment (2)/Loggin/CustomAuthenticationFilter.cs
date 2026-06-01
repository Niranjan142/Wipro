using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomAuthenticationFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(
        ActionExecutingContext context)
    {
        var user =
            context.HttpContext.Session.GetString("User");

        if (string.IsNullOrEmpty(user))
        {
            context.Result =
                new RedirectToActionResult(
                    "Login",
                    "Account",
                    null);
        }
    }
}
