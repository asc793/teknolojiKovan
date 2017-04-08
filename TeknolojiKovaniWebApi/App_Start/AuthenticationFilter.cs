using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using TeknolojiKovaniWebApi.Domain.Authentication;
using TeknolojiKovaniWebApi.Domain.Authentication.DTOs;

namespace TeknolojiKovaniWebApi.App_Start
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.FirstOrDefault(i => i.Key == "token");

            if (token.Value == null)
            {
                throw new Exception("Token Required");
            }

            ValidateToken validateToken = new ValidateToken();
            try
            {
                validateToken = new ValidateToken()
                                {
                                    DeviceName = token.Value.FirstOrDefault().Split('_')[0]
                                    ,
                                    Token = token.Value.FirstOrDefault().Split('_')[1]
                                };
            }
            catch (Exception)
            {
                throw new Exception("Token format invalid");
            }


            AuthenticationDomain authDomain = new AuthenticationDomain();

            authDomain.ValidateToken(validateToken);


            base.OnActionExecuting(actionContext);
        }
    }
}