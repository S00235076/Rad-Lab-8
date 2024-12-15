namespace Pets.data.Models
{
    public class User : IdentityUser // Extend IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Vet> Pets { get; set; } = new List<Vet>();
    }

    public class Vet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } 
        public int UserId { get; set; }
        public User Owner { get; set; }
        public ICollection<VetVisit> VetVisits { get; set; } = new List<VetVisit>();
    }

    public class VetVisit
    {
        public int VetVisitId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int PetId { get; set; }
        public Vet Pet { get; set; }
    }

    public class Clinic
    {
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public ICollection<VetVisit> VetVisits { get; set; } = new List<VetVisit>();
    }
}