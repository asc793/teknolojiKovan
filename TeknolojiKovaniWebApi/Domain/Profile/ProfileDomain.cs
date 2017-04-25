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
    }
}