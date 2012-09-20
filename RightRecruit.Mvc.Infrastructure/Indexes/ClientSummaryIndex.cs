using System.Collections.Generic;
using System.Linq;
using Raven.Client.Indexes;
using RightRecruit.Domain;

namespace RightRecruit.Mvc.Infrastructure.Indexes
{
    public class ClientSummaryIndex : AbstractIndexCreationTask<Client, ClientSummaryIndex.Result>
    {
        public class Result
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
            public string Database { get; set; }
        }

        public ClientSummaryIndex()
        {
            Map = clients => from client in clients
                             select new
                                        {
                                            client.Id,
                                            client.Name,
                                            Industry = client.Industry.Name,
                                            Country = client.Address.Country.Name,
                                            Status = client.Status,
                                            client.Priority,
                                            client.Database,
                                            Contacts = client.Spocs.Where(s => !string.IsNullOrEmpty(s.Name)).Select(s => s.Name),
                                            NoOfPositions = client.Positions.Count,
                                        };

            Reduce = results => from result in results
                                group result by
                                new
                                    {
                                        result.Id,
                                        result.Name,
                                        result.Country,
                                        result.Industry,
                                        result.Contacts,
                                        result.NoOfPositions,
                                        result.Status,
                                        result.Priority,
                                        result.Database
                                    } into g
                                select new 
                                           {
                                               g.Key.Id,
                                               g.Key.Name,
                                               g.Key.Country,
                                               g.Key.Industry,
                                               g.Key.Contacts,
                                               g.Key.NoOfPositions,
                                               g.Key.Status,
                                               g.Key.Priority,
                                               g.Key.Database
                                           };
        }
    }
}