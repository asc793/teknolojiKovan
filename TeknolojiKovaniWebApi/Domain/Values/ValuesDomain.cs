using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknolojiKovaniWebApi.Domain.Device;
using TeknolojiKovaniWebApi.Domain.Device.DTOs;
using TeknolojiKovaniWebApi.Domain.Profile;
using TeknolojiKovaniWebApi.Domain.Profile.DTOs;
using TeknolojiKovaniWebApi.Domain.Values.DTOs.External;
using TeknolojiKovaniWebApi.Models.EntityClass;

namespace TeknolojiKovaniWebApi.Domain.Values
{
    public class ValuesDomain
    {
        internal void SaveValue(DTOs.External.DeviceValue value)
        {
            tKovanContext ctx = new tKovanContext();
            Models.EntityClass.DeviceValue deviceValue = new Models.EntityClass.DeviceValue();
            deviceValue.DataDeviceTime = value.DataDeviceTime;
            deviceValue.DeviceId = value.DeviceId;
            deviceValue.Value = value.Value;

            deviceValue.DataServerTime = DateTime.Now;
            deviceValue.DataDeviceTime = DateTime.Now;

            ProfileDomain profileDomain = new ProfileDomain();
            PropertyRead property = profileDomain.GetProperty(value.PropertyName);
            deviceValue.PropertyId = property.Id;

            DeviceDomain deviceDomain = new DeviceDomain();
            DeviceRead device = deviceDomain.GetDevice(value.DeviceId);
            deviceValue.EnvironmentId = device.EnvironmentId.Value;
            deviceValue.UserId = device.UserId;

            ctx.DeviceValue.Add(deviceValue);
            ctx.SaveChanges();
        }
    }
}