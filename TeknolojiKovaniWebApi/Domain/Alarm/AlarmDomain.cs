using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknolojiKovaniWebApi.Domain.Alarm.DTOs;
using TeknolojiKovaniWebApi.Domain.Device.DTOs;
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

        public AlarmList GetAlarmById(int Id)
        {

            tKovanContext ctx = new tKovanContext();
            TeknolojiKovaniWebApi.Models.EntityClass.Alarm Alarm= ctx.Alarm.Single(x => x.Id == Id);
            AlarmList dAlarm = new AlarmList();
            dAlarm = Utilities.Map<TeknolojiKovaniWebApi.Models.EntityClass.Alarm, AlarmList>(Alarm, dAlarm);
            return dAlarm;
        }

        public List<AlarmList> GetAlarmList(int UserId)
        {

            tKovanContext ctx = new tKovanContext();
            //List<DTOs.External.Environment> lstEnvironment = ctx.Environment.Where(x => x.UserId == UserId).ToList().Select(x => new DTOs.External.Environment { Id = x.Id, Name = x.Name }).ToList();
            //return lstEnvironment;
            List<AlarmList> AlarmList = new List<AlarmList>();
            List<DeviceList> device = ctx.Device.Where(x => x.UserId == UserId).ToList().Select(x => new DeviceList { CurrentToken = x.CurrentToken, DataSendInterval = x.DataSendInterval, EnvironmentName = x.Environment == null ? "" : x.Environment.Name, Id = x.Id, Name = x.Name, MacNo = x.MacNo, ProfileName = x.Profile == null ? "" : x.Profile.Name, UserName = x.User == null ? "" : x.User.UserName }).ToList();

            foreach (DeviceList item in device)
            {
                List<TeknolojiKovaniWebApi.Models.EntityClass.Alarm> DeviceAlarm = ctx.Alarm.Include("Device").Include("Property").Where(x => x.DeviceId == item.Id).ToList();
                foreach (TeknolojiKovaniWebApi.Models.EntityClass.Alarm it in DeviceAlarm)
                {
                    AlarmList dAlarm = new AlarmList();
                    dAlarm = Utilities.Map<TeknolojiKovaniWebApi.Models.EntityClass.Alarm,AlarmList>(it, dAlarm);
                    dAlarm.DeviceName = it.Device.Name;
                    dAlarm.PropertyName = it.Property.DisplayName;
                    AlarmList.Add(dAlarm);
                }
            }

            return AlarmList;
        }

        public bool SaveAlarm(AlarmList AlarmList)
        {
            try
            {
                tKovanContext ctx = new tKovanContext();
                TeknolojiKovaniWebApi.Models.EntityClass.Alarm Alarm = new Models.EntityClass.Alarm();
                Alarm = Utilities.Map<AlarmList, TeknolojiKovaniWebApi.Models.EntityClass.Alarm>(AlarmList, Alarm);
                ctx.Alarm.Add(Alarm);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAlarm(AlarmList AlarmList)
        {
            try
            {
                tKovanContext ctx = new tKovanContext();
                TeknolojiKovaniWebApi.Models.EntityClass.Alarm Alarm = ctx.Alarm.Single(x => x.Id == AlarmList.Id);

                Alarm.AlarmParameter = AlarmList.AlarmParameter;
                Alarm.AlarmType = AlarmList.AlarmType;
                Alarm.DeviceId = AlarmList.DeviceId;
                Alarm.Level = AlarmList.Level;
                Alarm.Max = AlarmList.Max;
                Alarm.Min = AlarmList.Min;
                Alarm.PinNo = AlarmList.PinNo;
                Alarm.PropertyId = AlarmList.PropertyId;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteAlarm(int Id)
        {
            try
            {
                tKovanContext ctx = new tKovanContext();
                Models.EntityClass.Alarm Alarm = ctx.Alarm.Single(x => x.Id == Id);
                ctx.Alarm.Remove(Alarm);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }
    }
}