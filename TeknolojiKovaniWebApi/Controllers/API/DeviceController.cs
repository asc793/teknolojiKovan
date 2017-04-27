using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Routing;
using TeknolojiKovaniWebApi.Models.EntityClass;

namespace TeknolojiKovaniWebApi.Controllers.API
{
    public class DeviceController : ApiController
    {
        [Route("api/Device/{deviceName}/Config")]
        [HttpGet]
        public IHttpActionResult GetDeviceConfig()
        {
            return Ok();
        }
    }
}
