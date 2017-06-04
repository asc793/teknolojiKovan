using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknolojiKovaniWebApi.Domain.Dashboard
{
    public class DashboardDomain
    {
        public List<DTOs.DeviceLastValue> GetAllDeviceAndLastStatus(int UserId)
        {
            tKovanContext ctx = new tKovanContext();
            List<DTOs.DeviceLastValue> DeviceLastValueList = new List<DTOs.DeviceLastValue>();
            List<Models.EntityClass.Device> Device = ctx.Device.Include("Profile").Include("Profile.SensorProfiles").Include("Profile.SensorProfiles.Sensor").Include("Profile.SensorProfiles.Sensor.Properties").Where(x => x.UserId == UserId).ToList();
            foreach (Models.EntityClass.Device itemDevice in Device)
            {
                if (itemDevice.Profile.SensorProfiles != null)
                {
                    foreach (Models.EntityClass.SensorProfile itemSensorProfile in itemDevice.Profile.SensorProfiles.ToList())
                    {
                        if (itemSensorProfile.Sensor.Properties != null)
                        {
                            foreach (Models.EntityClass.Property itemProperty in itemSensorProfile.Sensor.Properties)
                            {
                                DTOs.DeviceLastValue tDeviceLastValue = new DTOs.DeviceLastValue();
                                tDeviceLastValue.Id = itemDevice.Id;
                                tDeviceLastValue.DeviceName = itemDevice.Name;
                                tDeviceLastValue.PropertyId = itemProperty.Id;
                                tDeviceLastValue.PropertyName = itemProperty.DisplayName;
                                Models.EntityClass.DeviceValue DeviceLastValue = ctx.DeviceValue.Where(x => x.PropertyId == itemProperty.Id && x.DeviceId == itemDevice.Id).OrderByDescending(x => x.DataDeviceTime).FirstOrDefault();
                                if (DeviceLastValue != null)
                                {
                                    tDeviceLastValue.Value = DeviceLastValue.Value;
                                    tDeviceLastValue.DataDeviceTime = DeviceLastValue.DataDeviceTime;
                                }
                                DeviceLastValueList.Add(tDeviceLastValue);
                            }
                        }
                        else
                        {
                            DTOs.DeviceLastValue tDeviceLastValue = new DTOs.DeviceLastValue();
                            tDeviceLastValue.Id = itemDevice.Id;
                            tDeviceLastValue.DeviceName = itemDevice.Name;
                            tDeviceLastValue.PropertyName = "Tanımlı Property Yok";
                            tDeviceLastValue.Value = 0;
                            tDeviceLastValue.DataDeviceTime = new DateTime(1900, 1, 1);
                            DeviceLastValueList.Add(tDeviceLastValue);
                        }
                    }
                }
                else
                {
                    DTOs.DeviceLastValue tDeviceLastValue = new DTOs.DeviceLastValue();
                    tDeviceLastValue.Id = itemDevice.Id;
                    tDeviceLastValue.DeviceName = itemDevice.Name;
                    tDeviceLastValue.PropertyName = "Tanımlı Sensör Yok";
                    tDeviceLastValue.Value = 0;
                    tDeviceLastValue.DataDeviceTime = new DateTime(1900, 1, 1);
                    DeviceLastValueList.Add(tDeviceLastValue);
                }
            }
            return DeviceLastValueList;
        }

        public List<DTOs.AlarmLogList> GetAllAlarms(int UserId)
        {
            tKovanContext ctx = new tKovanContext();
            List<DTOs.AlarmLogList> AlarmLogList = new List<DTOs.AlarmLogList>();
            List<Models.EntityClass.Device> Device = ctx.Device.Include("Profile").Include("Profile.SensorProfiles").Include("Profile.SensorProfiles.Sensor").Include("Profile.SensorProfiles.Sensor.Properties").Where(x => x.UserId == UserId).ToList();
            foreach (Models.EntityClass.Device itemDevice in Device)
            {
                if (itemDevice.Profile.SensorProfiles != null)
                {
                    foreach (Models.EntityClass.SensorProfile itemSensorProfile in itemDevice.Profile.SensorProfiles.ToList())
                    {
                        if (itemSensorProfile.Sensor.Properties != null)
                        {
                            foreach (Models.EntityClass.Property itemProperty in itemSensorProfile.Sensor.Properties)
                            {
                                List<Models.EntityClass.DeviceValue> DeviceLastValues = ctx.DeviceValue.Where(x =>
                                    x.PropertyId == itemProperty.Id
                                    && x.DeviceId == itemDevice.Id
                                    && ctx.Alarm.Select(i => i.Id).Contains(x.AlarmId.Value)
                                    ).OrderByDescending(x => x.DataDeviceTime)
                                    .Take(5)
                                    .ToList();

                                foreach (Models.EntityClass.DeviceValue DeviceLastValue in DeviceLastValues)
                                {
                                    DTOs.AlarmLogList AlarmLog = new DTOs.AlarmLogList();
                                    AlarmLog.Id = itemDevice.Id;
                                    AlarmLog.DeviceName = itemDevice.Name;
                                    AlarmLog.PropertyName = itemProperty.DisplayName;
                                    AlarmLog.PropertyId = itemProperty.Id;
                                    AlarmLog.Value = DeviceLastValue.Value;
                                    AlarmLog.DataDeviceTime = DeviceLastValue.DataDeviceTime;
                                    AlarmLog.AlarmId = Convert.ToInt32(DeviceLastValue.AlarmId);

                                    Models.EntityClass.Alarm Alarm = ctx.Alarm.Single(x => x.Id == AlarmLog.AlarmId);

                                    AlarmLog.Max = Alarm.Max;
                                    AlarmLog.Min = Alarm.Min;

                                    AlarmLogList.Add(AlarmLog);
                                }
                            }
                        }
                    }
                }
            }
            return AlarmLogList;
        }

        public List<DTOs.Data> GetReportByDeviceId(Guid DeviceId)
        {
            List<DTOs.Data> DataList = new List<DTOs.Data>();
            tKovanContext ctx = new tKovanContext();
            Models.EntityClass.Device device = ctx.Device.Include("Profile").Include("Profile.SensorProfiles").Include("Profile.SensorProfiles.Sensor").Include("Profile.SensorProfiles.Sensor.Properties").Where(x => x.Id == DeviceId).FirstOrDefault();

            List<DTOs.DevicePropertyInfo> DpiList = new List<DTOs.DevicePropertyInfo>();


            if (device.Profile.SensorProfiles != null)
            {
                foreach (Models.EntityClass.SensorProfile itemSensorProfile in device.Profile.SensorProfiles.ToList())
                {
                    if (itemSensorProfile.Sensor.Properties != null)
                    {
                        foreach (Models.EntityClass.Property itemProperty in itemSensorProfile.Sensor.Properties)
                        {
                            DTOs.DevicePropertyInfo Dpi = new DTOs.DevicePropertyInfo();
                            Dpi.DeviceId = device.Id;
                            Dpi.DeviceName = device.Name;
                            Dpi.PropertyId = itemProperty.Id;
                            Dpi.PropertyName = itemProperty.Name;
                            DpiList.Add(Dpi);
                        }
                    }
                }
            }

            foreach (DTOs.DevicePropertyInfo dpi in DpiList)
            {

                DTOs.Data Data = new DTOs.Data();
                Data.type = "line";
                Data.name = dpi.DeviceName + "/" + dpi.PropertyName;
                Data.showInLegend = true;
                Data.dataPoints = new List<DTOs.DataPoint>();
                List<Models.EntityClass.DeviceValue> DeviceValues = ctx.DeviceValue.Where(x => x.DeviceId == DeviceId && x.PropertyId == dpi.PropertyId).ToList();
                int sayac = 0;
                foreach (Models.EntityClass.DeviceValue DeviceValue in DeviceValues)
                {

                    DTOs.DataPoint dp = new DTOs.DataPoint();
                    dp.x = sayac;
                    dp.y = DeviceValue.Value;
                    dp.label = DeviceValue.DataDeviceTime.ToString("dd.MM.yyyy HH:mm");
                    Data.dataPoints.Add(dp);
                    sayac++;

                }
                DataList.Add(Data);
            }

            return DataList;

        }

        public DTOs.Data GetReportByDeviceIdAndPropertyId(Guid DeviceId, int PropertyId)
        {
            tKovanContext ctx = new tKovanContext();


            Models.EntityClass.Device Device = ctx.Device.Single(x => x.Id == DeviceId);
            Models.EntityClass.Property Property = ctx.Property.Single(x => x.Id == PropertyId);

            DTOs.Data Data = new DTOs.Data();
            Data.type = "line";
            Data.name = Device.Name + "/" + Property.Name;
            Data.showInLegend = true;
            Data.dataPoints = new List<DTOs.DataPoint>();

            List<Models.EntityClass.DeviceValue> DeviceValues = ctx.DeviceValue.Where(x => x.DeviceId == DeviceId && x.PropertyId == PropertyId).ToList();
            int sayac = 0;
            foreach (Models.EntityClass.DeviceValue DeviceValue in DeviceValues)
            {
                DTOs.DataPoint dp = new DTOs.DataPoint();
                dp.x = sayac;
                dp.y = DeviceValue.Value;
                dp.label = DeviceValue.DataDeviceTime.ToString("dd.MM.yyyy HH:mm");
                Data.dataPoints.Add(dp);
                sayac++;
            }
            return Data;
        }

    }
}
