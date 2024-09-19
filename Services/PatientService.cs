using csula.labs.HW2.Models;

namespace csula.labs.HW2.Services
{

    public interface IPatientService
    {

        List<Patient> GetPatients();

        Patient GetPatient(int id);

        void AddPatient(Patient patient);

        List<Vaccine> GetVaccines();

        List<Vaccine> GetAvailVaccines();

        Vaccine GetVaccine(int id);

        void SaveChanges();

    }

    public class PatientService :IPatientService
    {
        private readonly AppDbContext _db;
        

        public PatientService(AppDbContext db)
        {

            _db = db;
        }


        public void SaveChanges() => _db.SaveChanges();


        public List<Patient> GetPatients()
        {
            return _db.Patients.ToList();
        }


        public Patient GetPatient(int id)
        {
            return _db.Patients.Where(x => x.Id == id).Single();
        }


        //Add new patient
        public void AddPatient(Patient patient)
        {
            _db.Patients.Add(patient);
            _db.SaveChanges();
        }


        public List<Vaccine> GetVaccines() 
        { 
            return _db.Vaccines.ToList();
        }


        public List<Vaccine> GetAvailVaccines()
        {
            return _db.Vaccines.Where( v=> v.TotalDosesLeft != 0).ToList();
        }

        //Return a Single Vaccine
        public Vaccine GetVaccine(int id)
        {
            return _db.Vaccines.Where(e => e.Id == id).Single();
        }

    }
}
