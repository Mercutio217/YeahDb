namespace YeahDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicineBoxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Capacity = c.Int(nullable: false),
                        ActiveSubstanceAmountInMg = c.Single(nullable: false),
                        Medicine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicines", t => t.Medicine_Id)
                .Index(t => t.Medicine_Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrescriptedMedicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartUsageDate = c.DateTime(nullable: false),
                        PrescriptedBoxCount = c.Int(nullable: false),
                        Dose = c.Int(nullable: false),
                        Interval = c.Int(nullable: false),
                        MedicineBox_Id = c.Int(),
                        Prescription_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicineBoxes", t => t.MedicineBox_Id)
                .ForeignKey("dbo.Prescriptions", t => t.Prescription_Id)
                .Index(t => t.MedicineBox_Id)
                .Index(t => t.Prescription_Id);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfIssue = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrescriptedMedicines", "Prescription_Id", "dbo.Prescriptions");
            DropForeignKey("dbo.Prescriptions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PrescriptedMedicines", "MedicineBox_Id", "dbo.MedicineBoxes");
            DropForeignKey("dbo.MedicineBoxes", "Medicine_Id", "dbo.Medicines");
            DropIndex("dbo.Prescriptions", new[] { "User_Id" });
            DropIndex("dbo.PrescriptedMedicines", new[] { "Prescription_Id" });
            DropIndex("dbo.PrescriptedMedicines", new[] { "MedicineBox_Id" });
            DropIndex("dbo.MedicineBoxes", new[] { "Medicine_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.PrescriptedMedicines");
            DropTable("dbo.Medicines");
            DropTable("dbo.MedicineBoxes");
        }
    }
}
