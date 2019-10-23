using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
