using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeknolojiKovaniWebApi.Domain.Device.DTOs;
using TeknolojiKovaniWebApi.Domain.Values;
using TeknolojiKovaniWebApi.Domain.Values.DTOs.External;

namespace TeknolojiKovaniWebApi.Controllers.API
{
    public class ValueController : ApiController
    {
        [Route("api/Values/{propertyName}")]
        [HttpPost]
        public IHttpActionResult SaveValue(string propertyName, DeviceValue value)
        {
            DeviceRead currentDevice= StaticContext.GetCurrentDevice();
            value.DeviceId = currentDevice.Id;
            value.PropertyName = propertyName;
            ValuesDomain valuesDomain = new ValuesDomain();
            valuesDomain.SaveValue(value);
            return Ok();
        }
    }
}
