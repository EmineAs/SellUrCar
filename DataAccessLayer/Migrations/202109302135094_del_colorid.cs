namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class del_colorid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adverts", "ColorID", "dbo.Colors");
            DropIndex("dbo.Adverts", new[] { "ColorID" });
            AddColumn("dbo.Adverts", "Color", c => c.String(maxLength: 50));
            DropColumn("dbo.Adverts", "ColorID");
            DropTable("dbo.Colors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ColorID);
            
            AddColumn("dbo.Adverts", "ColorID", c => c.Int());
            DropColumn("dbo.Adverts", "Color");
            CreateIndex("dbo.Adverts", "ColorID");
            AddForeignKey("dbo.Adverts", "ColorID", "dbo.Colors", "ColorID");
        }
    }
}
