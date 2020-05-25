namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsOrderMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compouns", "IsOrder", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compouns", "IsOrder");
        }
    }
}
