namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compouns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfReception = c.String(),
                        TimeOfReception = c.String(),
                        PatientId = c.Int(),
                        DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(),
                        Position = c.String(nullable: false),
                        Experience = c.String(nullable: false),
                        NumberOfPhone = c.String(nullable: false),
                        Cabinet = c.String(),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Receptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfReception = c.String(nullable: false),
                        TimeOfBeginReception = c.String(nullable: false),
                        TimeOfEndReception = c.String(nullable: false),
                        PatientId = c.Int(),
                        DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        House = c.String(nullable: false, maxLength: 3),
                        Flat = c.String(nullable: false, maxLength: 3),
                        NumberOfPhone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeUser = c.String(),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 60),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Cost = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceDoctors",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Doctor_Id })
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.ServiceReceptions",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Reception_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Reception_Id })
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Receptions", t => t.Reception_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Reception_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "Id", "dbo.Users");
            DropForeignKey("dbo.ServiceReceptions", "Reception_Id", "dbo.Receptions");
            DropForeignKey("dbo.ServiceReceptions", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.ServiceDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.ServiceDoctors", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Patients", "Id", "dbo.Users");
            DropForeignKey("dbo.Receptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Compouns", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Receptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Compouns", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.ServiceReceptions", new[] { "Reception_Id" });
            DropIndex("dbo.ServiceReceptions", new[] { "Service_Id" });
            DropIndex("dbo.ServiceDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.ServiceDoctors", new[] { "Service_Id" });
            DropIndex("dbo.Patients", new[] { "Id" });
            DropIndex("dbo.Receptions", new[] { "DoctorId" });
            DropIndex("dbo.Receptions", new[] { "PatientId" });
            DropIndex("dbo.Doctors", new[] { "Id" });
            DropIndex("dbo.Compouns", new[] { "DoctorId" });
            DropIndex("dbo.Compouns", new[] { "PatientId" });
            DropTable("dbo.ServiceReceptions");
            DropTable("dbo.ServiceDoctors");
            DropTable("dbo.Services");
            DropTable("dbo.Users");
            DropTable("dbo.Patients");
            DropTable("dbo.Receptions");
            DropTable("dbo.Doctors");
            DropTable("dbo.Compouns");
        }
    }
}
