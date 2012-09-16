using System;

namespace RightRecruit.Domain
{
    public abstract class Entity : INamedDocument
    {
        public string Id {get; set;}
        public string Name {get; set;}
        public DateTime LastUpdatedDate {get; set;}
        public string LastUpdatedUserId {get; set;}
        public DateTime CreatedDate {get; set;}
        public string CreatedByUserId {get; set;}
        public string Database { get; set; }
    }
}