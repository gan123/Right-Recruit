using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Raven.Client.Indexes;
using RightRecruit.Domain;

namespace RightRecruit.Mvc.Infrastructure.Indexes
{
    public class ClientSearchIndex : AbstractIndexCreationTask<Client>
    {
        public ClientSearchIndex()
        {
            Map = clients => from client in clients
                             select new
                                        {
                                            Name = client.Name + " " + client.AlternateName + " " + client.Industry.Name,
                                            client.Database
                                        };
        }
    }
}