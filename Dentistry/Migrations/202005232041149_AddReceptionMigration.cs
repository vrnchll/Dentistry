namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReceptionMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceReceptions", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.ServiceReceptions", "Reception_Id", "dbo.Receptions");
            DropIndex("dbo.ServiceReceptions", new[] { "Service_Id" });
            DropIndex("dbo.ServiceReceptions", new[] { "Reception_Id" });
            AddColumn("dbo.Receptions", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Receptions", "ServiceId");
            AddForeignKey("dbo.Receptions", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
            DropTable("dbo.ServiceReceptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceReceptions",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Reception_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Reception_Id });
            
            DropForeignKey("dbo.Receptions", "ServiceId", "dbo.Services");
            DropIndex("dbo.Receptions", new[] { "ServiceId" });
            DropColumn("dbo.Receptions", "ServiceId");
            CreateIndex("dbo.ServiceReceptions", "Reception_Id");
            CreateIndex("dbo.ServiceReceptions", "Service_Id");
            AddForeignKey("dbo.ServiceReceptions", "Reception_Id", "dbo.Receptions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ServiceReceptions", "Service_Id", "dbo.Services", "Id", cascadeDelete: true);
        }
    }
}
