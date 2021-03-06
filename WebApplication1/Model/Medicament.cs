using System.Collections.Generic;

namespace WebApplication1.Model
{
    public class Medicament
    {
        public Medicament()
        {
            Medicaments_Prescriptions = new HashSet<Prescription_Medicament>();
        }
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Prescription_Medicament> Medicaments_Prescriptions { get; set; }

    }
}