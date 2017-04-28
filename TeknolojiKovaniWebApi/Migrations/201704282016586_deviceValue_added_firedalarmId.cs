namespace TeknolojiKovaniWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deviceValue_added_firedalarmId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alarm", "AlarmParameter", c => c.String());
            AddColumn("dbo.DeviceValue", "AlarmId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeviceValue", "AlarmId");
            DropColumn("dbo.Alarm", "AlarmParameter");
        }
    }
}
