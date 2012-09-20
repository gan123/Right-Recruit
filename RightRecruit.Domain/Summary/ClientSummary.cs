using System.Collections.Generic;

namespace RightRecruit.Domain.Summary
{
    public class ClientSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public string Industry { get; set; }
        public string Country { get; set; }
        public IList<string> Contacts { get; set; }
        public string Status { get; set; }
        public int? NoOfPositions { get; set; }
        public double? BookedRev { get; set; }
        public double? ProjectedRev { get; set; }
    }
}