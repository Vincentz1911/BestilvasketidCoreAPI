using System;

namespace BestilVasketidCore.Models
{
    public class TimeStamp
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deleted { get; set; }
        public DateTime Changed { get; set; }
    }
}
