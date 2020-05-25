namespace Dentistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationPatient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Street", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Patients", "Flat", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Flat", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Patients", "Street", c => c.String());
            AlterColumn("dbo.Patients", "City", c => c.String());
        }
    }
}
