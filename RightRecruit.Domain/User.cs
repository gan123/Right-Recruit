using System;

namespace RightRecruit.Domain
{
    public class User : Entity
    {
        public Address Address {get; set;}
        public SocialContact Contact {get; set;}
        public string Username {get; set;}
        public Password Password {get; set;}
        public UserStatus UserStatus {get; set;}
        public Salutation Salutation { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Name NameDetail { get; set; }
        public AttachmentReference PhotoAttachment { get; set; }
    }

    public class Name
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public enum Salutation
    {
        Mrs,
        Mr,
        Ms
    }
}