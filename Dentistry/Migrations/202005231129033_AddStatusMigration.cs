namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Compouns", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Compouns", "Status", c => c.Boolean(nullable: false));
        }
    }
}
