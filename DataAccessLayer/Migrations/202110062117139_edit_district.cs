namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_district : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Districts", "DistrictName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Districts", "DistrictName", c => c.String(maxLength: 10));
        }
    }
}
