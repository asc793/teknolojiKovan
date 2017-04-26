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
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["UserCookie"];
                UserId = Convert.ToInt32(cookie.Values["Id"]);
                Domain.Environment.EnvironmentDomain ed = new Domain.Environment.EnvironmentDomain();
                Environment = ed.GetAll(UserId).ToList();
            }
            return View(Environment);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Domain.Environment.DTOs.External.Environment Environment)
        {

            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["UserCookie"];
                int UserId = Convert.ToInt32(cookie.Values["Id"]);
                Environment.UserId = UserId;
                Domain.Environment.EnvironmentDomain ed = new Domain.Environment.EnvironmentDomain();
                ed.SaveEnvironment(Environment);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");

        }
    }
}