using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using Raven.Json.Linq;
using RightRecruit.Domain;
using RightRecruit.Mvc.Infrastructure.Indexes;
using RightRecruit.Mvc.Infrastructure.Security;

namespace RightRecruit.Data.Setup
{
    class Program
    {
        private const string Database = "TalentCorner";
        private static IDocumentStore _store;

        static void Main()
        {
            //LoadPlaces();
            //LoadIndustries();
            //CreateAgency();
            UploadImage();
            //GetImage();
            //LoadStatus();
            //CreateClients();
            //GetStore();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Completed successfully");
            Console.ReadLine();
        }

        static void UploadImage()
        {
            const string deepikaPhoto = @"H:\Workspace\deepika-ganesh.jpg";
            var byteArray = File.ReadAllBytes(deepikaPhoto);
            var store = GetStore();

            using(var session = store.OpenSession())
            {
                var deepika = session.Query<User>().SingleOrDefault(u => u.Username == "deepika");
                store.DatabaseCommands.PutAttachment("photos/" + deepika.Username, null, new MemoryStream(byteArray), new RavenJObject
                                                                                                                          {
                                                                                                                              {"ContentType", "image/jpeg"}
                                                                                                                          });
                deepika.PhotoAttachment = new AttachmentReference { AttachmentId = "photos/" + deepika.Username };
                session.SaveChanges();
            }
        }

        static void GetImage()
        {
            var store = GetStore();
            var attachment = store.DatabaseCommands.GetAttachment("photos/deepika");
            var stream = attachment.Data();
            using (var fs = File.Create(@"H:\Workspace\deepika-tmp.jpg"))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fs);
                fs.Close();
            }
        }

        static void LoadIndustries()
        {
            using(var session = GetStore().OpenSession())
            {
                var tech = new Industry { Id = "industries/tech", Name = "Technology" };
                var healthCare = new Industry { Id = "industries/health", Name = "Health Care" };
                var banking = new Industry { Id = "industries/bank", Name = "Banking" };
                var advertising = new Industry { Id = "industries/advert", Name = "Advertising" };
                var chemical = new Industry { Id = "industries/chem", Name = "Chemicals" };
                var natres = new Industry { Id = "industries/natres", Name = "Natural resources" };
                var industrial = new Industry { Id = "industries/industrial", Name = "Industrial" };
                var retail = new Industry { Id = "industries/retail", Name = "Retail" };
                var communication = new Industry { Id = "industries/comm", Name = "Communications" };

                session.Store(tech);
                session.Store(healthCare);
                session.Store(banking);
                session.Store(advertising);
                session.Store(chemical);
                session.Store(natres);
                session.Store(industrial);
                session.Store(retail);
                session.Store(communication);

                session.SaveChanges();
            }
        }

        static void LoadStatus()
        {
            using(var session = GetStore().OpenSession())
            {
                var active = new EntityStatus{Id = "entitystatuses/active", Name = "Active"};
                var inactive = new EntityStatus { Id = "entitystatuses/inactive", Name = "Inactive" };

                session.Store(active);
                session.Store(inactive);
                session.SaveChanges();
            }
        }

        static void CreateClients()
        {
            City mumbai;
            State maharashtra;
            Country india;
            Recruiter deepika;
            Agency agency;
            Industry tech;

            using (var session = GetStore().OpenSession())
            {
                mumbai = session.Load<City>("cities/mumbai");
                maharashtra = session.Load<State>("states/maharashtra");
                india = session.Load<Country>("countries/india");
                deepika = session.Query<Recruiter>().Single(u => u.Username == "deepika");
                agency = session.Query<Agency>().Single(a => a.Database == Database);
                tech = session.Load<Industry>("industries/tech");
                var active = session.Load<EntityStatus>("entitytstatuses/active");
                var address = new Address
                                  {
                                      City = mumbai,
                                      Country = india,
                                      State = maharashtra,
                                      Street1 = "Some address",
                                      Pincode = 123333
                                  };
                var contact = new SocialContact
                                  {
                                      Phone = new Phone {Office = "+917785464"},
                                      Email = "client2@domain.com"
                                  };
                Console.WriteLine("Creating new client");
                var client1 = new Client
                                  {
                                      Address = address,
                                      Name = "Infosys Technologies",
                                      AlternateName = "Infy",
                                      Contact = contact,
                                      CreatedByUserId = deepika.Id,
                                      CreatedDate = DateTime.Now,
                                      LastUpdatedDate = DateTime.Now,
                                      LastUpdatedUserId = deepika.Id,
                                      Agency = agency,
                                      Industry = tech,
                                      Database = Database,
                                      Priority = Priority.Platinum,
                                      Status = active
                                  };
                session.Store(client1);
                session.SaveChanges();
                Console.WriteLine("New client created");

                Console.WriteLine("Client spoc creation begins");
                var pwd = GeneratePassword("client2");
                var clientUser1 = new ClientUser
                                      {
                                          Client = client1,
                                          Name = "Client contact 2",
                                          NameDetail =
                                          new Name { FirstName = "Client", LastName = "Contact", NickName = "CC" },
                                          Contact = contact,
                                          CreatedByUserId = deepika.Id,
                                          CreatedDate = DateTime.Now,
                                          LastUpdatedDate = DateTime.Now,
                                          LastUpdatedUserId = deepika.Id,
                                          Password = pwd.Password,
                                          Database = Database
                                      };
                session.Store(clientUser1);
                session.SaveChanges();
                Console.WriteLine("Client spoc create");

                Console.WriteLine("Assigning spoc to client 1");
                client1.Spocs = new Collection<DenormalizedReference<ClientUser>>{clientUser1};
                session.SaveChanges();
                Console.WriteLine("Client user 1 assigned as spoc to client 1");

                Console.WriteLine("Creating new client");
                var client2 = new Client
                                  {
                                      Address = address,
                                      Name = "Tata Consultance Services",
                                      AlternateName = "TCS",
                                      Contact = contact,
                                      CreatedByUserId = deepika.Id,
                                      CreatedDate = DateTime.Now,
                                      LastUpdatedDate = DateTime.Now,
                                      LastUpdatedUserId = deepika.Id,
                                      Agency = agency,
                                      Industry = tech,
                                      Database = Database,
                                      Priority = Priority.Diamond,
                                      Status = active
                                  };
                session.Store(client2);
                session.SaveChanges();
                Console.WriteLine("New client created");

                Console.WriteLine("Client spoc creation begins");
                var pwd1 = GeneratePassword("client3");
                var clientUser2 = new ClientUser
                                      {
                                          Client = client1,
                                          Name = "Client contact 2",
                                          NameDetail =
                                              new Name {FirstName = "Client", LastName = "Contact", NickName = "CC"},
                                          Contact = contact,
                                          CreatedByUserId = deepika.Id,
                                          CreatedDate = DateTime.Now,
                                          LastUpdatedDate = DateTime.Now,
                                          LastUpdatedUserId = deepika.Id,
                                          Password = pwd1.Password,
                                          Database = Database
                                      };
                session.Store(clientUser2);
                session.SaveChanges();
                Console.WriteLine("Client spoc create");

                Console.WriteLine("Assigning spoc to client 1");
                client2.Spocs = new Collection<DenormalizedReference<ClientUser>> { clientUser2 };
                session.SaveChanges();
                Console.WriteLine("Client user 1 assigned as spoc to client 1");

                Console.WriteLine("Creating new client");
                var accenture = new Client
                                    {
                                        Address = address,
                                        Name = "Accenture",
                                        AlternateName = "Accenture",
                                        Contact = contact,
                                        CreatedByUserId = deepika.Id,
                                        CreatedDate = DateTime.Now,
                                        LastUpdatedDate = DateTime.Now,
                                        LastUpdatedUserId = deepika.Id,
                                        Agency = agency,
                                        Industry = tech,
                                        Database = Database,
                                        Priority = Priority.Gold,
                                        Status = active
                                    };
                session.Store(accenture);
                session.SaveChanges();
                Console.WriteLine("New client created");

                Console.WriteLine("Client spoc creation begins");
                var pwd3 = GeneratePassword("client4");
                var aacentureUser = new ClientUser
                                        {
                                            Client = client1,
                                            Name = "Accenture contact 2",
                                            NameDetail =
                                                new Name {FirstName = "Client", LastName = "Contact", NickName = "CC"},
                                            Contact = contact,
                                            CreatedByUserId = deepika.Id,
                                            CreatedDate = DateTime.Now,
                                            LastUpdatedDate = DateTime.Now,
                                            LastUpdatedUserId = deepika.Id,
                                            Password = pwd3.Password,
                                            Database = Database
                                        };
                session.Store(aacentureUser);
                session.SaveChanges();
                Console.WriteLine("Client spoc create");

                Console.WriteLine("Assigning spoc to client 1");
                accenture.Spocs = new Collection<DenormalizedReference<ClientUser>> { aacentureUser };
                session.SaveChanges();
                Console.WriteLine("Client user 1 assigned as spoc to client 1");
            }
        }

        static void CreateAgency()
        {
            var store = GetStore();
            using (var session = store.OpenSession())
            {
                var mumbai = session.Load<City>("cities/mumbai");
                var maharashtra = session.Load<State>("states/maharashtra");
                var india = session.Load<Country>("countries/india");
                Console.WriteLine("Staring to create agency");
                var agency = new Agency
                                 {
                                     Address = new Address
                                                   {
                                                       City = mumbai,
                                                       Country = india,
                                                       State = maharashtra,
                                                       Pincode = 400055,
                                                       Street1 = "Swastik chamber, Near shreyas cinemas",
                                                       Street2 = "Ghatkopar"
                                                   },
                                     Contact = new SocialContact
                                                   {
                                                       AlternateEmail = "someemail@talentcorner.co.in",
                                                       Email = "someemail@talentcorner.co.in",
                                                       Phone = new Phone {Office = "+9122666666"}
                                                   },
                                     Name = "Talent corner HR services",
                                     LastUpdatedDate = DateTime.Now,
                                     CreatedByUserId = "system",
                                     LastUpdatedUserId = "system",
                                     CreatedDate = DateTime.Now,
                                     Database = Database
                                 };
                session.Store(agency);
                session.SaveChanges();
                Console.WriteLine("agency created with id: {0}", agency.Id);

                Console.WriteLine("Creating users");
                var rashishPwd = GeneratePassword("rashish");
                Console.WriteLine("Generated password for rashish : {0}", rashishPwd.OriginalPassword);
                var rashish = new Recruiter
                                  {
                                      IsAdmin = true,
                                      IsTeamLead = true,
                                      IsGlobalAdmin = true,
                                      IsManager = true,
                                      Name = "Rashish Doshi",
                                      NameDetail =
                                          new Name { FirstName = "Rashish", LastName = "Doshi", NickName = "Rashish" },
                                      Rating = 5,
                                      Salutation = Salutation.Mr,
                                      Username = "rashish",
                                      Password = rashishPwd.Password,
                                      IsWorkingFromHome = false,
                                      DateOfBirth = new DateTime(1983, 5, 22),
                                      Agency = agency,
                                      DateOfJoining = new DateTime(2007, 10, 5),
                                      Age = 29,
                                      UserStatus = UserStatus.Active,
                                      Contact = new SocialContact
                                                    {
                                                        Email = "rashish.doshi@talentcorner.co.in",
                                                        Phone =
                                                            new Phone
                                                                {Mobile = "+9112345678"},
                                                        AlternateEmail = "rashish.doshi@talentcorner.co.in"
                                                    },
                                      LastUpdatedDate = DateTime.Now,
                                      LastUpdatedUserId = "system",
                                      CreatedByUserId = "system",
                                      CreatedDate = DateTime.Now,
                                      Address = new Address
                                      {
                                          City = mumbai,
                                          Country = india,
                                          State = maharashtra,
                                          Pincode = 3121321
                                      },
                                      Database = Database
                                  };
                session.Store(rashish);
                session.SaveChanges();

                var deepikaPwd = GeneratePassword("deepika");
                Console.WriteLine("Generated password deepika : {0}", deepikaPwd.OriginalPassword);
                var deepika = new Recruiter
                                  {
                                      IsAdmin = true,
                                      IsTeamLead = true,
                                      IsGlobalAdmin = true,
                                      IsManager = true,
                                      Name = "Deepika Ganesh",
                                      NameDetail =
                                          new Name {FirstName = "Deepika", LastName = "Ganesh", NickName = "Deepu"},
                                      Rating = 5,
                                      Salutation = Salutation.Mrs,
                                      Username = "deepika",
                                      Password = deepikaPwd.Password,
                                      IsWorkingFromHome = false,
                                      DateOfBirth = new DateTime(1984, 5, 22),
                                      Agency = agency,
                                      DateOfJoining = new DateTime(2011, 10, 5),
                                      Age = 28,
                                      UserStatus = UserStatus.Active,
                                      Contact = new SocialContact
                                                    {
                                                        Email = "deepika.ganesh@talentcorner.co.in",
                                                        Phone =
                                                            new Phone
                                                                {Mobile = "+919967659294", Residence = "+912265175313"},
                                                        AlternateEmail = "deeps_1984@yahoo.com"
                                                    },
                                      ReportsTo = rashish,
                                      LastUpdatedDate = DateTime.Now,
                                      LastUpdatedUserId = "system",
                                      CreatedByUserId = "system",
                                      CreatedDate = DateTime.Now,
                                      Address = new Address
                                                    {
                                                        City = mumbai,
                                                        Country = india,
                                                        State = maharashtra,
                                                        Pincode = 3121321
                                                    },
                                      Database = Database
                                  };
                session.Store(deepika);
                session.SaveChanges();
                Console.WriteLine("Users created");

                Console.WriteLine("Adding recruiters to agency");
                agency.Recruiters = new Collection<DenormalizedReference<Recruiter>> { rashish, deepika };
                session.SaveChanges();
                Console.WriteLine("added recruiters to agency");
            }
        }

        static void LoadPlaces()
        {
            using(var session = GetStore().OpenSession())
            {
                Console.WriteLine("Start loading countries");
                var india = new Country {Id= "countries/india", Code = "IND", Name = "India"};
                session.Store(india);
                session.SaveChanges();
                Console.WriteLine("Countries loaded");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Start loading states");
                var ap = new State {Id="states/andhra", Name = "Andhra Pradesh", Country = india};
                session.Store(ap);
                var arp = new State { Id = "states/arunachal", Name = "Arunachal Pradesh", Country = india };
                session.Store(arp);
                var assam = new State { Id = "states/assam", Name = "Assam", Country = india };
                session.Store(assam);
                var bihar = new State { Id = "states/bihar", Name = "Bihar", Country = india };
                session.Store(bihar);
                var chhattisgarh = new State { Id = "states/chhattisgarh", Name = "Chhattisgarh", Country = india };
                session.Store(chhattisgarh);
                var goa = new State { Id = "states/goa", Name = "Goa", Country = india };
                session.Store(goa);
                var guj = new State { Id = "states/gujarat", Name = "Gujarat", Country = india };
                session.Store(guj);
                var haryana = new State { Id = "states/haryana", Name = "Haryana", Country = india };
                session.Store(haryana);
                var hp = new State { Id = "states/himachal", Name = "Himachal Pradesh", Country = india };
                session.Store(hp);
                var jnk = new State { Id = "states/jnk", Name = "Jammu & Kashmir", Country = india };
                session.Store(jnk);
                var jharkhand = new State { Id = "states/jharkhand", Name = "Jharkhand", Country = india };
                session.Store(jharkhand);
                var karnataka = new State { Id = "states/karnataka", Name = "Karnataka", Country = india };
                session.Store(karnataka);
                var kerala = new State { Id = "states/kerala", Name = "Kerala", Country = india };
                session.Store(kerala);
                var mp = new State { Id = "states/mp", Name = "Madhya Pradesh", Country = india };
                session.Store(mp);
                var maharashtra = new State { Id = "states/maharashtra", Name = "Maharashtra", Country = india };
                session.Store(maharashtra);
                var manipur = new State { Id = "states/manipur", Name = "Manipur", Country = india };
                session.Store(manipur);
                var meghalaya = new State { Id = "states/meghalaya", Name = "Meghalaya", Country = india };
                session.Store(meghalaya);
                var mizoram = new State { Id = "states/mizoram", Name = "Mizoram", Country = india };
                session.Store(mizoram);
                var nagaland = new State { Id = "states/nagaland", Name = "Nagaland", Country = india };
                session.Store(nagaland);
                var orissa = new State { Id = "states/orissa", Name = "Orissa", Country = india };
                session.Store(orissa);
                var punjab = new State { Id = "states/punjab", Name = "Punjab", Country = india };
                session.Store(punjab);
                var rajasthan = new State { Id = "states/rajasthan", Name = "Rajasthan", Country = india };
                session.Store(rajasthan);
                var sikkim = new State { Id = "states/sikkim", Name = "Sikkim", Country = india };
                session.Store(sikkim);
                var tn = new State { Id = "states/tamilnadu", Name = "Tamil Nadu", Country = india };
                session.Store(tn);
                var tripura = new State { Id = "states/tripura", Name = "Tripura", Country = india };
                session.Store(tripura);
                var up = new State { Id = "states/uttar", Name = "Uttar Pradesh", Country = india };
                session.Store(up);
                var uttarakhand = new State { Id = "states/uttarakhand", Name = "Uttarakhand", Country = india };
                session.Store(uttarakhand);
                var wb = new State { Id = "states/bengal", Name = "West Bengal", Country = india };
                session.Store(wb);
                session.SaveChanges();
                Console.WriteLine("States loaded");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Start loading cities");
                var mumbai = new City {Id = "cities/mumbai", Name = "Mumbai", State = maharashtra};
                session.Store(mumbai);
                var amaravati = new City { Id = "cities/amaravati", Name = "Amaravati", State = maharashtra };
                session.Store(amaravati);
                var aurangabad = new City { Id = "cities/aurangabad", Name = "Aurangabad", State = maharashtra };
                session.Store(aurangabad);
                var nagpur = new City { Id = "cities/nagpur", Name = "Nagpur", State = maharashtra };
                session.Store(nagpur);
                var pune = new City { Id = "cities/pune", Name = "Pune", State = maharashtra };
                session.Store(pune);
                session.SaveChanges();
                Console.WriteLine("Cities loaded");
            }
        }

        static IDocumentStore GetStore()
        {
            if (_store == null)
            {
                _store = new DocumentStore
                {
                    Url = ConfigurationManager.AppSettings["RavenServerUrl"],
                    Credentials = new NetworkCredential(
                        ConfigurationManager.AppSettings["RavenUser"],
                        ConfigurationManager.AppSettings["RavenPassword"]),
                    Conventions =
                    {
                        FindTypeTagName = type =>
                        {
                            if (typeof(Recruiter).IsAssignableFrom(type) || typeof(ClientUser).IsAssignableFrom(type) || typeof(Candidate).IsAssignableFrom(type))
                                return "Users";

                            return DocumentConvention.DefaultTypeTagName(type);
                        }
                    }
                };
                _store.Initialize();
                IndexCreation.CreateIndexes(typeof(ClientSearchIndex).Assembly, _store);
            }
            
            return _store;
        }

        public static GeneratedPassword GeneratePassword(string passwordString = null)
        {
            var password = !string.IsNullOrEmpty(passwordString) ? passwordString : RandomPasswordGenerator.Generate(8);
            string salt;
            string hash;
            new SaltedHash().GetHashAndSaltString(password, out hash, out salt);
            return new GeneratedPassword
            {
                Password = new Password(password.ToByteArray(), salt.ToByteArray(), hash.ToByteArray()),
                OriginalPassword = password
            };
        }
    }
}
