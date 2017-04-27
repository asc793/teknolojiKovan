using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiKovaniWebApi.Functions;

namespace TeknolojiKovaniWebApi.Controllers.MVC
{
    [CustomAuthorize]
    public class DevicesController : Controller
    {
        // GET: Device
        public ActionResult Index()
        {
            List<Domain.Device.DTOs.DeviceList> DeviceList = new List<Domain.Device.DTOs.DeviceList>();
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["UserCookie"];
                int UserId = Convert.ToInt32(cookie.Values["Id"]);
                Domain.Device.DeviceDomain dd = new Domain.Device.DeviceDomain();
                DeviceList = dd.GetDeviceList(UserId);
            }
            return View(DeviceList);
        }

        public ActionResult Create()
        {
            Domain.Profile.ProfileDomain pd = new Domain.Profile.ProfileDomain();
            Domain.Environment.EnvironmentDomain ed = new Domain.Environment.EnvironmentDomain();
            int UserId = 0;
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["UserCookie"];
                UserId = Convert.ToInt32(cookie.Values["Id"]);
            }

            ViewBag.Profiller = pd.GetProfileList();
            ViewBag.Environment = ed.GetAll(UserId);

            return View();
        }

        [HttpPost]
        public ActionResult Create(Domain.Device.DTOs.DeviceRead device)
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["UserCookie"];
                int UserId = Convert.ToInt32(cookie.Values["Id"]);
                device.UserId = UserId;
                Domain.Device.DeviceDomain dd = new Domain.Device.DeviceDomain();
                dd.SaveDevice(device);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }


    }
}
