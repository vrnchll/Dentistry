namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statuscompoun : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compouns", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compouns", "Status");
        }
    }
}
