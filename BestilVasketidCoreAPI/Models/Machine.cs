using BestilVasketidCore.Models;

namespace BestilVasketidCoreAPI.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Duration { get; set; }
        public int TimeStamp { get; set; }
        public int Laundry { get; set; }
    }

    public class DTO_Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Duration { get; set; }
        public TimeStamp TimeStamp { get; set; }
        public Laundry Laundry { get; set; }

    }
}
