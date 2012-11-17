using System.Collections.Generic;

namespace RightRecruit.Models
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AlternativeNames { get; set; }
        public string Website { get; set; }
        public Industry SelectedIndustry { get; set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }
        public Priority Priority { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}