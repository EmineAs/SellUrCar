namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_advert2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "AdvertTitle", c => c.String(maxLength: 50));
            AddColumn("dbo.Adverts", "AdvertDetail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "AdvertDetail");
            DropColumn("dbo.Adverts", "AdvertTitle");
        }
    }
}
