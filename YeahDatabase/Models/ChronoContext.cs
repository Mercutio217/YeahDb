using System.Data.Entity;

namespace ChronoPiller.Models
{
    public class ChronoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PrescriptedMedicine> PrescriptedMedicines { get; set; }
        public DbSet<MedicineBox> MedicineBoxes { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}