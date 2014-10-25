using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Utils.Web
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked. Validates the model state.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
            else if (actionContext.ActionArguments.ContainsValue(null))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request body is empty.");
            }
        }
    }
}
