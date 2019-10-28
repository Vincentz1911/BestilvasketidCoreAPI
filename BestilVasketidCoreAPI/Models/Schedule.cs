using System;

namespace BestilVasketidCoreAPI.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Status { get; set; }
        public int User { get; set; }
        public int? TimeStamp { get; set; }
        public int Machine { get; set; }
    }

    public class DTO_Schedule
    {
        public Schedule Schedule { get; set; }
        public ScheduleStatus Status { get; set; }
        public User User { get; set; }
        public TimeStamp TimeStamp { get; set; }
        public Machine Machine { get; set; }
    }

}
