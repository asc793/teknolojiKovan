using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeknolojiKovaniWebApi.Controllers.API
{
    public class EnvironmentController : ApiController
    {
        [Route("Environment/{environmentId}")]
        [HttpGet]
        public IHttpActionResult GetEnvironment(int environmentId)
        {
            return Ok();
        }

        [Route("Environment/{environmentId}/Devices")]
        [HttpGet]
        public IHttpActionResult GetEnvironmentDevices(int environmentId)
        {
            return Ok();
        }
    }
}
