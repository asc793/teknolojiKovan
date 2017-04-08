using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Authentication.DTOs
{
    public class ValidateToken
    {
        public string DeviceName { get; set; }
        public string Token { get; set; }
    }
}