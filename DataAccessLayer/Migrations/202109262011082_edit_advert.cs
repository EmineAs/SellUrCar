namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_advert : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adverts", "ModelYear", c => c.String(maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adverts", "ModelYear", c => c.DateTime());
        }
    }
}
