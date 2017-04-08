using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Authentication.DTOs
{
    public class GetToken
    {
        public string Macno { get; set; }
        public string DeviceGuid { get; set; }
    }
}