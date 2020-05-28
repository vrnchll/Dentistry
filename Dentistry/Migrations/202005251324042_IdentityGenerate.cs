namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityGenerate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compouns", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Receptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.ServiceDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Compouns", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Receptions", "PatientId", "dbo.Patients");
            DropIndex("dbo.Doctors", new[] { "Id" });
            DropIndex("dbo.Patients", new[] { "Id" });
            DropPrimaryKey("dbo.Doctors");
            DropPrimaryKey("dbo.Patients");
            AlterColumn("dbo.Doctors", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Patients", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Doctors", "Id");
            AddPrimaryKey("dbo.Patients", "Id");
            CreateIndex("dbo.Doctors", "Id");
            CreateIndex("dbo.Patients", "Id");
            CreateIndex("dbo.Users", "UserName", unique: true);
            AddForeignKey("dbo.Compouns", "DoctorId", "dbo.Doctors", "Id");
            AddForeignKey("dbo.Receptions", "DoctorId", "dbo.Doctors", "Id");
            AddForeignKey("dbo.ServiceDoctors", "Doctor_Id", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Compouns", "PatientId", "dbo.Patients", "Id");
            AddForeignKey("dbo.Receptions", "PatientId", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Compouns", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.ServiceDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Receptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Compouns", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Patients", new[] { "Id" });
            DropIndex("dbo.Doctors", new[] { "Id" });
            DropPrimaryKey("dbo.Patients");
            DropPrimaryKey("dbo.Doctors");
            AlterColumn("dbo.Patients", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Patients", "Id");
            AddPrimaryKey("dbo.Doctors", "Id");
            CreateIndex("dbo.Patients", "Id");
            CreateIndex("dbo.Doctors", "Id");
            AddForeignKey("dbo.Receptions", "PatientId", "dbo.Patients", "Id");
            AddForeignKey("dbo.Compouns", "PatientId", "dbo.Patients", "Id");
            AddForeignKey("dbo.ServiceDoctors", "Doctor_Id", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Receptions", "DoctorId", "dbo.Doctors", "Id");
            AddForeignKey("dbo.Compouns", "DoctorId", "dbo.Doctors", "Id");
        }
    }
}
