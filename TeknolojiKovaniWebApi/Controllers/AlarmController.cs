using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeknolojiKovaniWebApi.Controllers
{
    public class AlarmController : ApiController
    {
        [Route("FireAlarm")]
        [HttpPost]
        public IHttpActionResult FireAlarm()
        {
            return Ok();
        }
    }
}
