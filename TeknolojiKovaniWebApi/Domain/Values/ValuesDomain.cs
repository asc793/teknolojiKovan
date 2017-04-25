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
        internal void SaveValue(DTOs.External.DeviceValue value)
        {
            tKovanContext ctx = new tKovanContext();
            Models.EntityClass.DeviceValue deviceValue = new Models.EntityClass.DeviceValue();
            deviceValue.DataDeviceTime = value.DataDeviceTime;
            deviceValue.DeviceId = value.DeviceId;
            deviceValue.Value= value.Value;

            deviceValue.DataServerTime = DateTime.Now;
            deviceValue.DataDeviceTime = DateTime.Now;

            Property prop = ctx.Property.Single(i => i.Name == value.PropertyName);


            deviceValue.PropertyId = prop.Id;

            ctx.DeviceValue.Add(deviceValue);
            ctx.SaveChanges();
        }
    }
}