namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_advert1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adverts", "CurrentMilage", c => c.String(maxLength: 20));
            AlterColumn("dbo.Adverts", "EnginValume", c => c.String(maxLength: 20));
            AlterColumn("dbo.Adverts", "EnginPower", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adverts", "EnginPower", c => c.String(maxLength: 5));
            AlterColumn("dbo.Adverts", "EnginValume", c => c.String(maxLength: 5));
            AlterColumn("dbo.Adverts", "CurrentMilage", c => c.String(maxLength: 6));
        }
    }
}
