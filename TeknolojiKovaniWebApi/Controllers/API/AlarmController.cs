using System;
using System.Web.Http;
using TeknolojiKovaniWebApi.Domain.Alarm;
using TeknolojiKovaniWebApi.Domain.Alarm.DTOs;
using TeknolojiKovaniWebApi.Domain.Alarm.DTOs.External;
using TeknolojiKovaniWebApi.Domain.Device.DTOs;
using TeknolojiKovaniWebApi.Domain.Values;
using TeknolojiKovaniWebApi.Domain.Values.DTOs.External;

namespace TeknolojiKovaniWebApi.Controllers.API
{
    public class AlarmController : ApiController
    {
        [Route("api/FireAlarm")]
        [HttpPost]
        public IHttpActionResult FireAlarm(FireAlarm alarm)
        {
            AlarmDomain alarmDomain = new AlarmDomain();
            DeviceRead currentDevice = StaticContext.GetCurrentDevice();

            if (currentDevice == null)
            {
                throw new UnauthorizedAccessException("Device token required");
            }

            ValuesDomain valuesDomain = new ValuesDomain();
            DeviceValue val = new DeviceValue();
            val = Utilities.Map<FireAlarm, DeviceValue>(alarm, val);
            val.DeviceId = currentDevice.Id;
            val.AlarmId = alarm.AlarmId;
            valuesDomain.SaveValue(val);



            if (alarm.Side == "onserver")
            {
                AlarmFireDto alarmDto = new AlarmFireDto();
                alarmDto = Utilities.Map<FireAlarm, AlarmFireDto>(alarm, alarmDto);
                alarmDomain.FireAlarm(alarmDto);

            }
            return Ok();
        }
    }
}
