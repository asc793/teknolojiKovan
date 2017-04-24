namespace TeknolojiKovaniWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alarm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Guid(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        AlarmType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Device", t => t.DeviceId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.Device",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        MacNo = c.String(),
                        CurrentToken = c.String(),
                        ProfileId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        EnvironmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Environment", t => t.EnvironmentId)
                .ForeignKey("dbo.Profile", t => t.ProfileId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ProfileId)
                .Index(t => t.UserId)
                .Index(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.Environment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Guid(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        ValueString = c.String(),
                        DataDeviceTime = c.DateTime(nullable: false),
                        DataServerTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Device", t => t.DeviceId)
                .ForeignKey("dbo.Property", t => t.PropertyId)
                .Index(t => t.DeviceId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceValue", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Property", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.DeviceValue", "DeviceId", "dbo.Device");
            DropForeignKey("dbo.Alarm", "DeviceId", "dbo.Device");
            DropForeignKey("dbo.Device", "UserId", "dbo.Users");
            DropForeignKey("dbo.Device", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.Device", "EnvironmentId", "dbo.Environment");
            DropIndex("dbo.Property", new[] { "ProfileId" });
            DropIndex("dbo.DeviceValue", new[] { "PropertyId" });
            DropIndex("dbo.DeviceValue", new[] { "DeviceId" });
            DropIndex("dbo.Device", new[] { "EnvironmentId" });
            DropIndex("dbo.Device", new[] { "UserId" });
            DropIndex("dbo.Device", new[] { "ProfileId" });
            DropIndex("dbo.Alarm", new[] { "DeviceId" });
            DropTable("dbo.Property");
            DropTable("dbo.DeviceValue");
            DropTable("dbo.Users");
            DropTable("dbo.Profile");
            DropTable("dbo.Environment");
            DropTable("dbo.Device");
            DropTable("dbo.Alarm");
        }
    }
}