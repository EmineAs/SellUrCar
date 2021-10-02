namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_advert3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "AdDescription", c => c.String());
            DropColumn("dbo.Adverts", "AdvertDetail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "AdvertDetail", c => c.String());
            DropColumn("dbo.Adverts", "AdDescription");
        }
    }
}
