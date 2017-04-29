using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeknolojiKovaniWebApi.Controllers.MVC
{
    public class AlarmsController : Controller
    {
        // GET: Alarms
        public ActionResult Index()
        {
        
            List<Domain.Alarm.DTOs.AlarmList> AlarmList = new List<Domain.Alarm.DTOs.AlarmList>();
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["UserCookie"];
                int UserId = Convert.ToInt32(cookie.Values["Id"]);
                Domain.Alarm.AlarmDomain ad = new Domain.Alarm.AlarmDomain();
                AlarmList = ad.GetAlarmList(UserId);
            }
            return View(AlarmList);
            
        }
        public ActionResult Create()
        {
            Domain.Device.DeviceDomain dd = new Domain.Device.DeviceDomain();
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserCookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["UserCookie"];
                int UserId = Convert.ToInt32(cookie.Values["Id"]);
                ViewBag.Devices = dd.GetDeviceList(UserId);
                Domain.Profile.ProfileDomain pd = new Domain.Profile.ProfileDomain();
                ViewBag.Properties = pd.GetProfileList();

            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Domain.Alarm.DTOs.AlarmList AlarmList)
        {
            Domain.Alarm.AlarmDomain ad = new Domain.Alarm.AlarmDomain();
            ad.SaveAlarm(AlarmList);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Domain.Alarm.AlarmDomain ad = new Domain.Alarm.AlarmDomain();
            ad.DeleteAlarm(Id);
            return RedirectToAction("Index");
        }
    }
}