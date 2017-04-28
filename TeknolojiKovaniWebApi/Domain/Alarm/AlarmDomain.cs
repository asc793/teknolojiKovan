using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknolojiKovaniWebApi.Domain.Alarm.DTOs;
using TeknolojiKovaniWebApi.Domain.Values;
using TeknolojiKovaniWebApi.Domain.Values.DTOs.External;

namespace TeknolojiKovaniWebApi.Domain.Alarm
{
    public class AlarmDomain
    {
        internal void FireAlarm(AlarmFireDto alarm)
        {
            tKovanContext ctx = new tKovanContext();

            TeknolojiKovaniWebApi.Models.EntityClass.Alarm alarmEnt = ctx.Alarm.FirstOrDefault(i => i.Id == alarm.AlarmId);

            alarmEnt = ctx.Alarm.Include("Device").Include("Property").FirstOrDefault(i => i.Id == alarm.AlarmId);

            AlarmNotification notification =new AlarmNotification();
            notification.DeviceName=alarmEnt.Device.Name;
            notification.Max = alarmEnt.Max;
            notification.Min = alarmEnt.Min;
            notification.NotificationParameter=alarmEnt.AlarmParameter;
            notification.Property=alarmEnt.Property.Name;
            notification.Value = alarm.Value;

            switch (alarmEnt.AlarmType)
            {
                case TeknolojiKovaniWebApi.Models.EntityClass.AlarmType.Sms:
                    break;
                case TeknolojiKovaniWebApi.Models.EntityClass.AlarmType.Email:
                    AlarmSendEmail(notification);
                    break;
                case TeknolojiKovaniWebApi.Models.EntityClass.AlarmType.VoiceCall:
                    break;
                case TeknolojiKovaniWebApi.Models.EntityClass.AlarmType.OnDevice:
                    break;
                default:
                    break;
            }
        }

        private void AlarmSendEmail(AlarmNotification notification)
        {

        }
    }
}