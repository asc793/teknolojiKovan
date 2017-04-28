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

        public List<DeviceList> GetDeviceList(int UserId)
        {
            tKovanContext ctx = new tKovanContext();
            List<DeviceList> device = ctx.Device.Where(x => x.UserId == UserId).ToList().Select(x=> new DeviceList { CurrentToken= x.CurrentToken, DataSendInterval= x.DataSendInterval, EnvironmentName = x.Environment==null?"":x.Environment.Name, Id= x.Id, Name= x.Name, MacNo= x.MacNo, ProfileName= x.Profile==null?"":x.Profile.Name, UserName = x.User==null?"":x.User.UserName  }).ToList();
            return device;
        }

        public bool SaveDevice(DTOs.DeviceRead device)
        {
            try
            {
                tKovanContext ctx = new tKovanContext();
                TeknolojiKovaniWebApi.Models.EntityClass.Device eDevice = new Models.EntityClass.Device();
                eDevice.CurrentToken = device.CurrentToken;
                eDevice.DataSendInterval = device.DataSendInterval;
                eDevice.EnvironmentId = device.EnvironmentId;
                eDevice.MacNo = device.MacNo;
                eDevice.Name = device.Name;
                eDevice.ProfileId = device.ProfileId;
                eDevice.UserId = device.UserId;
                //eDevice.UserId = device.UserId;
                ctx.Device.Add(eDevice);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;   
            }
            
        }
        public bool DeleteDevice(Guid Id)
        {
            try
            {
                tKovanContext ctx = new tKovanContext();
                TeknolojiKovaniWebApi.Models.EntityClass.Device eDevice = ctx.Device.Where(x => x.Id == Id).FirstOrDefault();
                ctx.Device.Remove(eDevice);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}