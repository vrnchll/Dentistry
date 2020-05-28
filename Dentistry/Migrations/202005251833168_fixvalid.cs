namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixvalid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "UserName" });
            AlterColumn("dbo.Compouns", "DateOfReception", c => c.String(nullable: false));
            AlterColumn("dbo.Compouns", "TimeOfReception", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Compouns", "TimeOfReception", c => c.String());
            AlterColumn("dbo.Compouns", "DateOfReception", c => c.String());
            CreateIndex("dbo.Users", "UserName", unique: true);
        }
    }
}
