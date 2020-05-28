namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compouns", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Receptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.ServiceDoctors", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Doctors", new[] { "Id" });
            DropPrimaryKey("dbo.Doctors");
            AlterColumn("dbo.Doctors", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Doctors", "Id");
            CreateIndex("dbo.Doctors", "Id");
            AddForeignKey("dbo.Compouns", "DoctorId", "dbo.Doctors", "Id");
            AddForeignKey("dbo.Receptions", "DoctorId", "dbo.Doctors", "Id");
            AddForeignKey("dbo.ServiceDoctors", "Doctor_Id", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Receptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Compouns", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Doctors", new[] { "Id" });
            DropPrimaryKey("dbo.Doctors");
            AlterColumn("dbo.Doctors", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Doctors", "Id");
            CreateIndex("dbo.Doctors", "Id");
            AddForeignKey("dbo.ServiceDoctors", "Doctor_Id", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Receptions", "DoctorId", "dbo.Doctors", "Id");
            AddForeignKey("dbo.Compouns", "DoctorId", "dbo.Doctors", "Id");
        }
    }
}
