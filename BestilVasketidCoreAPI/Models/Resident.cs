using BestilVasketidCoreAPI.Models;

namespace BestilVasketidCoreAPI.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Address { get; set; }
        public int Timestamp { get; set; }
    }

    public class DTO_Resident
    {
        public Resident Resident { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
        public TimeStamp Timestamp { get; set; }
    }
}
