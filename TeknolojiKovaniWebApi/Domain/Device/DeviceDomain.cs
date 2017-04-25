using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknolojiKovaniWebApi.Domain.Device;
using TeknolojiKovaniWebApi.Domain.Device.DTOs;

namespace TeknolojiKovaniWebApi.Domain.Device
{
    public class DeviceDomain
    {
        public DeviceRead GetDevice(Guid id)
        {
            tKovanContext ctx = new tKovanContext();

            Models.EntityClass.Device device = ctx.Device.Single(i => i.Id == id);

            DeviceRead deviceRead = new DeviceRead()
            {
                CurrentToken = device.CurrentToken
                ,
                DataSendInterval = device.DataSendInterval
                ,
                EnvironmentId = device.EnvironmentId
                ,
                Id = device.Id
                ,
                MacNo = device.MacNo
                ,
                Name = device.Name
                ,
                ProfileId = device.ProfileId
                ,
                UserId = device.UserId
            };


            return deviceRead;
        }
    }
}