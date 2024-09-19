using System.Threading.Tasks; 

namespace csula.labs.HW2.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DosesRequired { get; set; }
        public int DosesInBetween { get; set; }
        public int DosesRecieved { get; set; }
        public int TotalDosesLeft { get; set; }

        public List<Patient> Patients{get; set; }

        public Vaccine(){
        }    

        public Vaccine(int id , string name, int dosesRequired, int dosesInBetween, int dosesRecieved, int totalDosesLeft)
        {
            Id = id;
            Name = name;
            DosesRequired = dosesRequired;
            DosesInBetween = dosesInBetween;
            DosesRecieved = dosesRecieved;
            TotalDosesLeft = totalDosesLeft;
        }

        public override string ToString()
        {
            return $"{Id}, {Name} , {DosesRequired}, {DosesInBetween}, {DosesRecieved}, {TotalDosesLeft}";
        }
    }
}
