using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeknolojiKovaniWebApi.Controllers.MVC
{
    public class EnvironmentController : Controller
    {
        // GET: Environment
        public ActionResult Index()
        {
            //Domain.Users.DTOs.External.Users user = (Domain.Users.DTOs.External.Users)Session["KullaniciBilgileri"];
            int UserId = 0;
            List<Domain.Environment.DTOs.External.Environment> Environment = new List<Domain.Environment.DTOs.External.Environment>();
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["Cookie"];
                UserId = Convert.ToInt32(cookie.Values["UserId"]);
                Domain.Environment.EnvironmentDomain ed = new Domain.Environment.EnvironmentDomain();
                Environment= ed.GetAll(UserId).ToList();
            }
            return View(Environment);
        }
    }
}