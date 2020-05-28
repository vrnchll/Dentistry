namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compouns", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Receptions", "PatientId", "dbo.Patients");
            DropIndex("dbo.Patients", new[] { "Id" });
            DropPrimaryKey("dbo.Patients");
            AlterColumn("dbo.Patients", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Patients", "Id");
            CreateIndex("dbo.Patients", "Id");
            AddForeignKey("dbo.Compouns", "PatientId", "dbo.Patients", "Id");
            AddForeignKey("dbo.Receptions", "PatientId", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Compouns", "PatientId", "dbo.Patients");
            DropIndex("dbo.Patients", new[] { "Id" });
            DropPrimaryKey("dbo.Patients");
            AlterColumn("dbo.Patients", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patients", "Id");
            CreateIndex("dbo.Patients", "Id");
            AddForeignKey("dbo.Receptions", "PatientId", "dbo.Patients", "Id");
            AddForeignKey("dbo.Compouns", "PatientId", "dbo.Patients", "Id");
        }
    }
}
