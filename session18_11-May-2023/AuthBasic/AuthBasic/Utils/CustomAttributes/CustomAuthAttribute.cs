using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthBasic.Utils.CustomAttributes {
    public class CustomAuthAttribute : AuthorizeAttribute, IAuthorizationFilter {
        public void OnAuthorization(AuthorizationFilterContext context) {
            string UserId = context.HttpContext.Session.GetString("UserId");

            if (string.IsNullOrWhiteSpace(UserId)) {
                context.Result = new UnauthorizedResult();
                return;
            } else {
                context.Result = new RedirectToActionResult("Index", "Dashboard", null);
                return;
            }
        }
    }
}
