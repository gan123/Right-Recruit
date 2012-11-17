namespace RightRecruit.Models
{
    public class Address
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string Pincode { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
    }
}