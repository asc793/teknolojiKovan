using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknolojiKovaniWebApi.Domain.Authentication.DTOs;

namespace TeknolojiKovaniWebApi.Domain.Authentication
{
    public class AuthenticationDomain
    {
        public string GenerateDeviceToken(GetToken token)
        {
            tKovanContext ctx = new tKovanContext();
            Models.EntityClass.Device dev = ctx.Device.FirstOrDefault(i => i.DeviceGuid == token.DeviceGuid && i.DeviceMacNo == token.Macno);

            if (dev != null)
            {
                string currentToken = Guid.NewGuid().ToString();
                dev.CurrentToken = currentToken;
                ctx.SaveChanges();
                return currentToken;
            }

            else
            {
                throw new Exception("Device bilgileri hatalı");
            }
        }

        public void ValidateToken(ValidateToken token)
        {
            tKovanContext ctx = new tKovanContext();
            Models.EntityClass.Device dev = ctx.Device.FirstOrDefault(i => i.DeviceName == token.DeviceName);

            if (dev == null)
            {
                throw new Exception("Device not found");
            }

            if (dev.CurrentToken != token.Token)
            {
                throw new Exception("Token invalid");
            }

        }
    }
}