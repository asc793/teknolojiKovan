using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeknolojiKovaniWebApi.Controllers
{
    public class ValueController : ApiController
    {
        [Route("Devices/{deviceName}/Values/{propertyName}")]
        [HttpPost]
        public IHttpActionResult FireAlarm()
        {
            return Ok();
        }
    }
}
