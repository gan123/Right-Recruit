using System.Collections.Generic;

namespace RightRecruit.Models
{
    public class ClientSearch
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Country { get; set; }
        public string TechnologyAndCountry
        {
            get { return string.Format("{0} - {1}", Industry, Country); }
        }
        public string Contacts { get; set; }
        public int NoOfPositions { get; set; }
        public double? BookedRev { get; set; }
        public double? ProjectedRev { get; set; }
        public string Status { get; set; }
        public string StatusClass
        {
            get { return Status == "Active" ? "green" : "yellow"; }
        }
        public double BookedRevWidth
        {
            get
            {
                if (BookedRev == null) return 0;
                if (ProjectedRev == null) return 220;
                var total = BookedRev + ProjectedRev;
                return (double) (220*(BookedRev/total));
            }
        }
        public double ProjectedRevWidth
        {
            get
            {
                if (ProjectedRev == null) return 0;
                if (BookedRev == null) return 220;
                var total = BookedRev + ProjectedRev;
                return (double)(220 * (ProjectedRev / total));
            }
        }

        public string Priority { get; set; }
    }
}