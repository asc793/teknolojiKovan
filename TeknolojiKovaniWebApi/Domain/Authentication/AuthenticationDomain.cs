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
            Models.EntityClass.Device dev = ctx.Device.FirstOrDefault(i => i.Id.ToString() == token.DeviceGuid && i.MacNo == token.Macno);

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

        public void ValidateToken(Guid token)
        {
            tKovanContext ctx = new tKovanContext();
            Models.EntityClass.Device dev = ctx.Device.FirstOrDefault(i => i.CurrentToken == token.ToString());

            if (dev == null)
            {
                throw new Exception("Token invalid");
            }
        }
    }
}