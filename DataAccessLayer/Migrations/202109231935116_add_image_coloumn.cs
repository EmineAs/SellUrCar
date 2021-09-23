namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_image_coloumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageName");
        }
    }
}
