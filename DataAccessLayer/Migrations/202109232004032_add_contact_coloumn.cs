namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_contact_coloumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactStatus");
        }
    }
}
