namespace TeknolojiKovaniWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profileEntitiesChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Property", "ProfileId", "dbo.Profile");
            DropIndex("dbo.Property", new[] { "ProfileId" });
            CreateTable(
                "dbo.Sensor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SensorType = c.Int(nullable: false),
                        PinNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SensorProfile",
                c => new
                    {
                        SensorId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SensorId, t.ProfileId })
                .ForeignKey("dbo.Sensor", t => t.SensorId, cascadeDelete: true)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.SensorId)
                .Index(t => t.ProfileId);
            
            AddColumn("dbo.Alarm", "Level", c => c.Int(nullable: false));
            AddColumn("dbo.Device", "DataReadInterval", c => c.Int(nullable: false));
            AddColumn("dbo.Property", "SensorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Property", "SensorId");
            AddForeignKey("dbo.Property", "SensorId", "dbo.Sensor", "Id", cascadeDelete: true);
            DropColumn("dbo.Property", "ProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Property", "ProfileId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Property", "SensorId", "dbo.Sensor");
            DropForeignKey("dbo.SensorProfile", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.SensorProfile", "SensorId", "dbo.Sensor");
            DropIndex("dbo.SensorProfile", new[] { "ProfileId" });
            DropIndex("dbo.SensorProfile", new[] { "SensorId" });
            DropIndex("dbo.Property", new[] { "SensorId" });
            DropColumn("dbo.Property", "SensorId");
            DropColumn("dbo.Device", "DataReadInterval");
            DropColumn("dbo.Alarm", "Level");
            DropTable("dbo.SensorProfile");
            DropTable("dbo.Sensor");
            CreateIndex("dbo.Property", "ProfileId");
            AddForeignKey("dbo.Property", "ProfileId", "dbo.Profile", "Id", cascadeDelete: true);
        }
    }
}
