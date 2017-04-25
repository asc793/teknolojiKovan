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
            Domain.Environment.EnvironmentDomain ed = new Domain.Environment.EnvironmentDomain();
            ed.GetAll()
            return View();
        }
    }
}