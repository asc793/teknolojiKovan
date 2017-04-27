using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeknolojiKovaniWebApi.Domain.Users.DTOs.External;

namespace TeknolojiKovaniWebApi.Functions
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        tKovanContext db = new tKovanContext();
        public string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] Roles)
        {
            this.allowedroles = Roles;
        }
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            bool authorize = false;
            if (System.Web.HttpContext.Current.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["UserCookie"];
                int UserId = Convert.ToInt32(cookie.Values["Id"]);
                if (UserId != 0)
                {
                    if (allowedroles.Length > 0)
                    {
                        foreach (var role in allowedroles)
                        {
                            //var user = db.Kullanicilar.Where(m => m.kullaniciID == kullaniciBilgileri.kullaniciID && m.rol.rolAdi == role);
                            var user = db.Users.Where(m => m.Id == UserId);
                            if (user.Count() > 0)
                            {
                                authorize = true; /* return true if Entity has current user(active) with specific role */
                            }
                        }
                    }
                    else
                    {
                        authorize = true;
                    }
                }

            }
            return authorize;
            //}
            //return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            int UserId = 0;
            if (System.Web.HttpContext.Current.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["UserCookie"];
                UserId = Convert.ToInt32(cookie.Values["Id"]);
            }
            if (UserId != 0)
            {
                filterContext.Result = new EmptyResult();
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }
            else
            {
                filterContext.Result = new EmptyResult();
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }

        }
    }

}
