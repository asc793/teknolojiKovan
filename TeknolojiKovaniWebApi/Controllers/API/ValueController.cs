using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeknolojiKovaniWebApi.Domain.Values;
using TeknolojiKovaniWebApi.Domain.Values.DTOs.External;

namespace TeknolojiKovaniWebApi.Controllers.API
{
    public class ValueController : ApiController
    {
        [Route("api/Devices/{deviceId:guid}/Values/{propertyName}")]
        [HttpPost]
        public IHttpActionResult SaveValue(Guid deviceId,string propertyName, DeviceValue value)
        {
            value.DeviceId = deviceId;
            value.PropertyName = propertyName;
            ValuesDomain valuesDomain = new ValuesDomain();
            valuesDomain.SaveValue(value);
            return Ok();
        }
    }
}
