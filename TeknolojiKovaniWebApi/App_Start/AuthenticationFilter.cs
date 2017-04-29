using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using TeknolojiKovaniWebApi.Domain.Authentication;
using TeknolojiKovaniWebApi.Domain.Authentication.DTOs;

namespace TeknolojiKovaniWebApi.App_Start
{
    public class DontValidate : Attribute 
    {
 
    }
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<DontValidate>().Any())
            {
                // The controller action is decorated with the [DontValidate]
                // custom attribute => don't do anything.
                return;
            }

            var token = actionContext.Request.Headers.FirstOrDefault(i => i.Key == "token");

            if (token.Value == null)
            {
                throw new Exception("Token Required");
            }

            Guid? validateToken = null;
            try
            {
                validateToken = Guid.Parse(token.Value.FirstOrDefault());
            }
            catch (Exception)
            {
                throw new Exception("Token format invalid");
            }


            AuthenticationDomain authDomain = new AuthenticationDomain();

            authDomain.ValidateToken(validateToken.Value);


            base.OnActionExecuting(actionContext);
        }
    }
}