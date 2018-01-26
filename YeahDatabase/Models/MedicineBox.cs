using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChronoPiller.Models
{
    public class MedicineBox
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Medicine Medicine { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public float ActiveSubstanceAmountInMg { get; set; }
        public List<PrescriptedMedicine> OccurancesOnPrescriptions { get; set; }

        public MedicineBox(int capacity, float activeSubstanceAmountInMg)
        {
            Capacity = capacity;
            ActiveSubstanceAmountInMg = activeSubstanceAmountInMg;
        }
    }
}