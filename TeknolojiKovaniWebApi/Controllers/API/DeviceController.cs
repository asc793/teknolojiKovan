using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Routing;
using TeknolojiKovaniWebApi.Domain.Device;
using TeknolojiKovaniWebApi.Domain.Device.DTOs;
using TeknolojiKovaniWebApi.Models.EntityClass;

namespace TeknolojiKovaniWebApi.Controllers.API
{
    public class DeviceController : ApiController
    {
        [Route("api/Device/Config")]
        [HttpGet]
        public IHttpActionResult GetDeviceConfig()
        {
            DeviceDomain deviceDomain = new DeviceDomain();
            Guid currentDeviceId = StaticContext.GetCurrentDeviceId();
            DeviceConfig config = deviceDomain.GetDeviceConfig(currentDeviceId);
            return Ok(config);
        }

        [Route("api/Device/Commands")]
        [HttpGet]
        public IHttpActionResult GetDeviceCommands()
        {
            Guid currentDeviceId = StaticContext.GetCurrentDeviceId();
            DeviceDomain deviceDomain = new DeviceDomain();
            string[] commands = deviceDomain.GetDeviceCommands(currentDeviceId);
            return Ok(commands);
        }
    }
}
