using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Areas.AdminPanel.Filters
{
    public class CheckSession : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string data = context.HttpContext.Session.GetString("LoggedInUser");
            if (string.IsNullOrEmpty(data))
            {
                context.Result = new RedirectToActionResult("LogIn", "Authentication", null);
            }

        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {

        }
    }
}
