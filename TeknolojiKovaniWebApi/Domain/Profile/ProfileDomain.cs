using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknolojiKovaniWebApi.Domain.Profile.DTOs;
using TeknolojiKovaniWebApi.Models.EntityClass;

namespace TeknolojiKovaniWebApi.Domain.Profile
{
    public class ProfileDomain
    {
        public PropertyRead GetProperty(string propertyName)
        {
            tKovanContext ctx = new tKovanContext();
            Property prop = ctx.Property.Single(i => i.Name == propertyName);

            PropertyRead property = new PropertyRead()
            {
                Id = prop.Id
                ,
                Name = prop.Name
            };

            return property;
        }
        public List<ProfileRead> GetProfileList()
        {
            tKovanContext ctx = new tKovanContext();
            List<ProfileRead> ProfilList = ctx.Profile.Select(x => new ProfileRead { Id = x.Id, Name = x.Name }).ToList();
            return ProfilList;
        }

        public List<PropertyRead> GetPropertyList()
        { 
            tKovanContext ctx = new tKovanContext();
            List<PropertyRead> PropertyReadList = ctx.Property.Select(x => new PropertyRead { Id = x.Id, Name = x.Name }).ToList();
            return PropertyReadList;
        }

        public List<PropertyRead> GetPropertyListForDevice(Guid DeviceId)
        {
            tKovanContext ctx = new tKovanContext();
            List<int> propertiesId = ctx.Alarm.Where(x => x.DeviceId == DeviceId).Select(x => x.PropertyId).ToList();
            List<PropertyRead> PropertyReadList = ctx.Property.Where(x=> !propertiesId.Contains(x.Id)).Select(x => new PropertyRead { Id = x.Id, Name = x.Name }).ToList();
            return PropertyReadList;
        }
    }
}