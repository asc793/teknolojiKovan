using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeknolojiKovaniWebApi.Domain.Alarm.DTOs;

namespace TeknolojiKovaniWebApi.Controllers.API
{
    public class AlarmController : ApiController
    {
        [Route("api/FireAlarm")]
        [HttpPost]
        public IHttpActionResult FireAlarm(AlarmFireDto alarm)
        {
            return Ok();
        }
    }
}
