namespace TeknolojiKovaniWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sensorProfileRelationChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SensorProfile", "SensorId", "dbo.Sensor");
            DropForeignKey("dbo.SensorProfile", "ProfileId", "dbo.Profile");
            DropIndex("dbo.SensorProfile", new[] { "SensorId" });
            DropIndex("dbo.SensorProfile", new[] { "ProfileId" });
            DropTable("dbo.SensorProfile");
            CreateTable(
                "dbo.SensorProfile",
                c => new
                    {
                        SensorId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        PinNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SensorId, t.ProfileId })
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Sensor", t => t.SensorId, cascadeDelete: true)
                .Index(t => t.SensorId)
                .Index(t => t.ProfileId);
            
            DropColumn("dbo.Sensor", "PinNumber");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SensorProfile",
                c => new
                    {
                        SensorId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SensorId, t.ProfileId });
            
            AddColumn("dbo.Sensor", "PinNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.SensorProfile", "SensorId", "dbo.Sensor");
            DropForeignKey("dbo.SensorProfile", "ProfileId", "dbo.Profile");
            DropIndex("dbo.SensorProfile", new[] { "ProfileId" });
            DropIndex("dbo.SensorProfile", new[] { "SensorId" });
            DropTable("dbo.SensorProfile");
            CreateIndex("dbo.SensorProfile", "ProfileId");
            CreateIndex("dbo.SensorProfile", "SensorId");
            AddForeignKey("dbo.SensorProfile", "ProfileId", "dbo.Profile", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SensorProfile", "SensorId", "dbo.Sensor", "Id", cascadeDelete: true);
        }
    }
}
