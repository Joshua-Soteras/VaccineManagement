using System.ComponentModel.DataAnnotations.Schema;

namespace csula.labs.HW2.Models
{
    public class Patient
    {
        [Column("PatientId")]
        public int Id { get; set; }

        public string ? PatientName { get; set; }

        //Foreign Key: referencing the primary id from Vaccine 
        //Should be referenced as Id from Vaccine 
       
        public int VaccineCompanyId { get; set; }
        
        //References the Vaccine Object / Relationship propert
        public virtual Vaccine VaccineCompany { get; set; }

        public DateTime ? FirstDose {  get; set; } = DateTime.Now;

        public DateTime ? SecondDose { get; set; } 

        //Empty Constructor 
        public Patient() { }

        //Constructor 
        public Patient(int id, string patientName, int vaccineCompanyId, Vaccine vaccineCompany,DateTime firstDose, DateTime secondDose )
        {
            Id = id;
            PatientName = patientName;
            VaccineCompanyId = vaccineCompanyId;
            VaccineCompany = vaccineCompany;
            FirstDose = firstDose;
            SecondDose = secondDose;

        }
        
    }
}
