﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SensorProfile> SensorProfiles { get; set; }
    }
}