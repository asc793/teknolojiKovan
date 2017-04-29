namespace TeknolojiKovaniWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeviceCommand_entity_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceCommand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Guid(nullable: false),
                        Command = c.String(),
                        Executed = c.Boolean(nullable: false),
                        ExecutionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Device", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
            AddColumn("dbo.Property", "DisplayName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceCommand", "DeviceId", "dbo.Device");
            DropIndex("dbo.DeviceCommand", new[] { "DeviceId" });
            DropColumn("dbo.Property", "DisplayName");
            DropTable("dbo.DeviceCommand");
        }
    }
}
