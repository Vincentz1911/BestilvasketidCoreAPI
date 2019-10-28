using System;

namespace BestilVasketidCoreAPI.Models
{
    public class Laundry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pin { get; set; }
        public int ShowID { get; set; }
        public DateTime OpenHours { get; set; }
        public DateTime CloseHours { get; set; }
        public int ScheduleLimit { get; set; }
        public int DefaultDuration { get; set; }
        public int TimeStamp { get; set; }
        public int Address { get; set; }
    }

    public class DTO_Laundry
    {
        public Laundry laundry { get; set; }
        public LandryStatus landryStatus { get; set; }
        public TimeStamp timeStamp { get; set; }
        public Address address { get; set; }
    }
}