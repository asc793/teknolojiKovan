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
                        AlarmID = c.Int(nullable: false, identity: true),
                        DeviceID = c.Int(nullable: false),
                        PropertyID = c.Int(nullable: false),
                        AlarmType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlarmID);
            
            CreateTable(
                "dbo.Device",
                c => new
                    {
                        DeviceID = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(),
                        DeviceGuid = c.String(),
                        DeviceMacNo = c.String(),
                        CurrentToken = c.String(),
                        ProfileID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceID)
                .ForeignKey("dbo.Profile", t => t.ProfileID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.ProfileID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        ProfileName = c.String(),
                    })
                .PrimaryKey(t => t.ProfileID);
            
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
                "dbo.Property",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        PropertyName = c.String(),
                        PropertyType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Device", "UserID", "dbo.Users");
            DropForeignKey("dbo.Device", "ProfileID", "dbo.Profile");
            DropIndex("dbo.Device", new[] { "UserID" });
            DropIndex("dbo.Device", new[] { "ProfileID" });
            DropTable("dbo.Property");
            DropTable("dbo.Users");
            DropTable("dbo.Profile");
            DropTable("dbo.Device");
            DropTable("dbo.Alarm");
        }
    }
}
