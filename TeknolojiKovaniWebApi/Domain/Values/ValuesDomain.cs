using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknolojiKovaniWebApi.Domain.Values.DTOs.External;
using TeknolojiKovaniWebApi.Models.EntityClass;

namespace TeknolojiKovaniWebApi.Domain.Values
{
    public class ValuesDomain
    {
        internal void SaveValue(Value value)
        {
            tKovanContext ctx = new tKovanContext();
            DeviceValue deviceValue = new DeviceValue();
            deviceValue.DataDeviceTime = value.DataDeviceTime;
            deviceValue.DeviceId = value.DeviceId;
            deviceValue.ValueString = value.ValueString;

            deviceValue.DataServerTime = DateTime.Now;
            deviceValue.DataDeviceTime = DateTime.Now;

            Property prop = ctx.Property.Single(i => i.Name == value.PropertyName);


            deviceValue.PropertyId = prop.Id;

            ctx.DeviceValue.Add(deviceValue);
            ctx.SaveChanges();
        }
    }
}