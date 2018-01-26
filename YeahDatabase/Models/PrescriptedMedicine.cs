using System;
using System.ComponentModel.DataAnnotations;

namespace ChronoPiller.Models
{
    public class PrescriptedMedicine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public DateTime StartUsageDate { get; set; }
        [Required]
        public int PrescriptedBoxCount { get; set; }
        [Required]
        public Prescription Prescription { get; set; }
        [Required]
        public MedicineBox MedicineBox { get; set; }
        [Required]
        public int Dose { get; set; }
        [Required]
        public int Interval { get; set; }
        
//        public PrescriptedMedicine(string name, DateTime startUsageDate, int dose, int interval)
//        {
//            Name = name;
//            StartUsageDate = startUsageeDate;
//            Dose = dose;
//            Interval = interval;
//        }
    }
}