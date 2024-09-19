using System.Threading.Tasks;
using csula.labs.HW2.Models; 

namespace csula.labs.HW2.Services
{

    public interface IVaccineService
    {
        List<Vaccine> GetVaccines();

        Vaccine GetVaccine(int id);

        void SaveChanges(); 

        void AddVaccine(Vaccine vaccine);


       // List<Patient> GetPatients();
    }

    public class VaccineService : IVaccineService
    {

        private readonly AppDbContext _db;


        public VaccineService(AppDbContext db)
        {

            _db = db;
        }


        public void SaveChanges() => _db.SaveChanges();


        public List<Vaccine> GetVaccines()
        {
            return _db.Vaccines.ToList();

        }


        //Return a Single Vaccine
        public Vaccine GetVaccine(int id)
        {
            return _db.Vaccines.Where(e => e.Id == id).Single();
        }

       
        //Add new vaccine
        public void AddVaccine(Vaccine vaccine)
        {
            _db.Vaccines.Add(vaccine); 
            _db.SaveChanges();
        }


        //Edit vaccine 
        public void EditVaccine(int id)
        {
            var vaccine = GetVaccine(id);
            
        }


        /*
        public List<Patient> GetPatients()
        {
            return _db.Patients.ToList();

        }
        */


    }//End of Class VaccineService


    /*
    public class MockVaccineService : IVaccineService 
    {
        private List<Vaccine> vaccines;

        public MockVaccineService()
        {
            vaccines = new List<Vaccine>
            {
                //Create Two Vaccine Objects 
                (new Vaccine(10, "Pfizer/BioNTech", 2, 21, 100,100)),
                (new Vaccine(11, "Johnson&Johnson", 1, 0, 50,50))
            };
        }

        public List<Vaccine> GetVaccines()
        {
            return vaccines;
        }


    }//End of MockVaccineService Class
    */
    
    
}//End of namespace
