namespace YeahDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsWithAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicineBoxes", "Medicine_Id", "dbo.Medicines");
            DropForeignKey("dbo.PrescriptedMedicines", "MedicineBox_Id", "dbo.MedicineBoxes");
            DropForeignKey("dbo.PrescriptedMedicines", "Prescription_Id", "dbo.Prescriptions");
            DropForeignKey("dbo.Prescriptions", "User_Id", "dbo.Users");
            DropIndex("dbo.MedicineBoxes", new[] { "Medicine_Id" });
            DropIndex("dbo.PrescriptedMedicines", new[] { "MedicineBox_Id" });
            DropIndex("dbo.PrescriptedMedicines", new[] { "Prescription_Id" });
            DropIndex("dbo.Prescriptions", new[] { "User_Id" });
            AddColumn("dbo.PrescriptedMedicines", "Name", c => c.String());
            AddColumn("dbo.Users", "Login", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.MedicineBoxes", "Medicine_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicines", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.PrescriptedMedicines", "MedicineBox_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PrescriptedMedicines", "Prescription_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Prescriptions", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicineBoxes", "Medicine_Id");
            CreateIndex("dbo.PrescriptedMedicines", "MedicineBox_Id");
            CreateIndex("dbo.PrescriptedMedicines", "Prescription_Id");
            CreateIndex("dbo.Prescriptions", "User_Id");
            AddForeignKey("dbo.MedicineBoxes", "Medicine_Id", "dbo.Medicines", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PrescriptedMedicines", "MedicineBox_Id", "dbo.MedicineBoxes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PrescriptedMedicines", "Prescription_Id", "dbo.Prescriptions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PrescriptedMedicines", "Prescription_Id", "dbo.Prescriptions");
            DropForeignKey("dbo.PrescriptedMedicines", "MedicineBox_Id", "dbo.MedicineBoxes");
            DropForeignKey("dbo.MedicineBoxes", "Medicine_Id", "dbo.Medicines");
            DropIndex("dbo.Prescriptions", new[] { "User_Id" });
            DropIndex("dbo.PrescriptedMedicines", new[] { "Prescription_Id" });
            DropIndex("dbo.PrescriptedMedicines", new[] { "MedicineBox_Id" });
            DropIndex("dbo.MedicineBoxes", new[] { "Medicine_Id" });
            AlterColumn("dbo.Prescriptions", "User_Id", c => c.Int());
            AlterColumn("dbo.PrescriptedMedicines", "Prescription_Id", c => c.Int());
            AlterColumn("dbo.PrescriptedMedicines", "MedicineBox_Id", c => c.Int());
            AlterColumn("dbo.Medicines", "Name", c => c.String());
            AlterColumn("dbo.MedicineBoxes", "Medicine_Id", c => c.Int());
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Login");
            DropColumn("dbo.PrescriptedMedicines", "Name");
            CreateIndex("dbo.Prescriptions", "User_Id");
            CreateIndex("dbo.PrescriptedMedicines", "Prescription_Id");
            CreateIndex("dbo.PrescriptedMedicines", "MedicineBox_Id");
            CreateIndex("dbo.MedicineBoxes", "Medicine_Id");
            AddForeignKey("dbo.Prescriptions", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.PrescriptedMedicines", "Prescription_Id", "dbo.Prescriptions", "Id");
            AddForeignKey("dbo.PrescriptedMedicines", "MedicineBox_Id", "dbo.MedicineBoxes", "Id");
            AddForeignKey("dbo.MedicineBoxes", "Medicine_Id", "dbo.Medicines", "Id");
        }
    }
}
