using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TeknolojiKovaniWebApi.Models.EntityClass;

namespace TeknolojiKovaniWebApi
{
    public class tKovanContext:DbContext
    {
        public DbSet<Alarm> Alarm { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<DeviceValue> DeviceValue { get; set; }
        public DbSet<TeknolojiKovaniWebApi.Models.EntityClass.Environment> Environment { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<Users> Users { get; set; }
        
        public tKovanContext():base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}