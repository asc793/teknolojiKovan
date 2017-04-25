using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeknolojiKovaniWebApi.Domain.Authentication;
using TeknolojiKovaniWebApi.Domain.Authentication.DTOs;

namespace TeknolojiKovaniWebApi.Controllers.API
{
    public class AuthenticationController : ApiController
    {

        /// <summary>
        /// Device üzerinde bulunan id ve macno ile request yapılır. Device dan gönderilecek request lerin header ine eklemek üzere üretilecek token döndürür
        /// </summary>
        /// <param name="getToken"></param>
        /// <returns></returns>
        [Route("Token")]
        [HttpPost]
        public IHttpActionResult GetToken(GetToken getToken)
        {
            AuthenticationDomain authDomain = new AuthenticationDomain();
            string token = authDomain.GenerateDeviceToken(getToken);
            return Ok<string>(token);
        }
    }
}
