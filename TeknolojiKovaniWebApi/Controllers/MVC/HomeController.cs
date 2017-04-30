using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiKovaniWebApi.Functions;

namespace TeknolojiKovaniWebApi.Controllers.MVC
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TeknolojiKovaniWebApi.Domain.Dashboard.DashboardDomain dbd = new Domain.Dashboard.DashboardDomain();
            int UserId = 0;
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["UserCookie"];
                UserId = Convert.ToInt32(cookie.Values["Id"]);
            }
            ViewBag.GetDeviceLastStatu = dbd.GetAllDeviceAndLastStatus(UserId);
            ViewBag.AllAlarm= dbd.GetAllAlarms(UserId);
            return View();
        }
        public ActionResult DeviceChart(Guid Id)
        {
            ViewBag.DeviceId = Id;
            return View();
        }
        public ActionResult PropertyChart(Guid Id,int PropertyId)
        {
            ViewBag.DeviceId = Id;
            ViewBag.PropertyId = PropertyId;
            return View();
        }

        public ActionResult DeviceChartGetValue(Guid Id)
        {
            try
            {
                Domain.Dashboard.DashboardDomain dd = new Domain.Dashboard.DashboardDomain();
                List<Domain.Dashboard.DTOs.Data> Data = dd.GetReportByDeviceId(Id);
                return Json(Data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult PropertyChartGetValue(Guid Id,int PropertyId)
        {
            try
            {
                Domain.Dashboard.DashboardDomain dd = new Domain.Dashboard.DashboardDomain();
                Domain.Dashboard.DTOs.Data Data = dd.GetReportByDeviceIdAndPropertyId(Id,PropertyId);
                List<Domain.Dashboard.DTOs.Data> DataList = new List<Domain.Dashboard.DTOs.Data>();
                DataList.Add(Data);
                return Json(DataList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}