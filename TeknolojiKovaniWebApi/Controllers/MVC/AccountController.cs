using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeknolojiKovaniWebApi.Controllers.MVC
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Domain.Users.DTOs.External.Users User)
        {

            try
            {
                Domain.Users.UsersDomain ud = new Domain.Users.UsersDomain();
                Domain.Users.DTOs.External.Users gUser = ud.Login(User);


                HttpCookie cookie = new HttpCookie("UserCookie");
                cookie.Values["Id"] = gUser.Id.ToString();
                cookie.Values["UserName"] = gUser.UserName.ToString();
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                Session["KullaniciBilgileri"] = gUser;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Account");
            }
            
            
        }


    }
}