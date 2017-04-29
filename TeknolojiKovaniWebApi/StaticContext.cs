using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknolojiKovaniWebApi.Domain.Device.DTOs;

namespace TeknolojiKovaniWebApi
{
    public class StaticContext
    {
        public static Guid GetCurrentDeviceId()
        {
            DeviceRead device = GetCurrentDevice();
            if (device == null)
            {
                throw new Exception("Device token required");
            }
            else
            {
                return device.Id;
            }
        }
        public static DeviceRead GetCurrentDevice()
        {
            string token = HttpContext.Current.Request.Headers["token"];
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }
            else
            {
                tKovanContext ctx = new tKovanContext();
                Models.EntityClass.Device dev = ctx.Device.FirstOrDefault(i => i.CurrentToken == token.ToString());

                DeviceRead res = null;

                if (dev != null)
                {
                    res = Utilities.Map<Models.EntityClass.Device, DeviceRead>(dev, res);
                }

                return res;
            }

        }

    }
}