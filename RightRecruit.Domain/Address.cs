namespace RightRecruit.Domain
{
    public class Address
    {
        public string Street1 {get; set;}
        public string Street2 {get; set;}
        public string Street3 {get; set;}
        public DenormalizedReference<Country> Country {get; set;}
        public DenormalizedReference<State> State {get; set;}
        public DenormalizedReference<City> City {get; set;}
        public int Pincode {get; set;}
    }
}