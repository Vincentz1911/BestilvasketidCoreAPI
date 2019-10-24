namespace BestilVasketidCoreAPI.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public int User { get; set; }
        public bool CanEditMachine { get; set; }
        public bool CanChangeDuration { get; set; }
        public bool CanChangeOpeningHours { get; set; }
        public bool CanDeleteEndUsers { get; set; }
        public bool CanDeleteAdmins { get; set; }
        public bool CanChangeShowID { get; set; }
        public bool CanChangeScheduleLimit { get; set; }
        public bool IsMaster { get; set; }
    }
}
