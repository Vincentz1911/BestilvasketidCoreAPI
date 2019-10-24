namespace BestilVasketidCoreAPI.Models
{
    public class Address
    {
        public int id { get; set; }
        public string Streetname { get; set; }
        public int Housenumber { get; set; }
        public string Floor { get; set; }
        public string  Door { get; set; }
        public int zipcode { get; set; }
        public string City { get; set; }
    }
}
