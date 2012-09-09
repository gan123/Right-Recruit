using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;
using Raven.Json.Linq;
using RightRecruit.Domain;
using RightRecruit.Mvc.Infrastructure.Security;

namespace RightRecruit.Data.Setup
{
    class Program
    {
        static void Main()
        {
            //LoadPlaces();
            //CreateAgency();
            UploadImage();
            GetImage();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Completed successfully");
            Console.ReadLine();
        }

        static void UploadImage()
        {
            const string deepikaPhoto = @"H:\Workspace\deepika-ganesh.jpg";
            var byteArray = System.IO.File.ReadAllBytes(deepikaPhoto);
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

        static void CreateAgency()
        {
            var store = GetStore();
            using (var session = store.OpenSession())
            {
                var mumbai = session.Load<City>("cities/mumbai");
                var maharashtra = session.Load<State>("states/maharashtra");
                var india = session.Load<Country>("countries/india");
                const string databse = "TalentCorner";
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
                                     DatabaseName = databse
                                 };
                session.Store(agency);
                session.SaveChanges();
                Console.WriteLine("agency created with id: {0}", agency.Id);

                Console.WriteLine("Creating user");
                var password = GeneratePassword();
                Console.WriteLine("Generated password : {0}", password.OriginalPassword);
                var deepika = new Recruiter
                                  {
                                      IsAdmin = true,
                                      IsTeamLead = true,
                                      IsGlobalAdmin = true,
                                      IsManager = true,
                                      Name = "Deepika Ganesh",
                                      NameDetail = new Name { FirstName = "Deepika", LastName = "Ganesh", NickName = "Deepu"},
                                      Rating = 5,
                                      Salutation = Salutation.Mrs,
                                      Username = "deepika",
                                      Password = password.Password,
                                      IsWorkingFromHome = false,
                                      DateOfBirth = new DateTime(1984, 5, 22),
                                      Agency = agency,
                                      DateOfJoining = new DateTime(2011, 10, 5),
                                      Age = 28,
                                      UserStatus = UserStatus.Active,
                                      Contact = new SocialContact
                                                    {
                                                        Email = "deepika.ganesh@talentcorner.co.in",
                                                        Phone = new Phone {Mobile = "+919967659294", Residence = "+912265175313"},
                                                        AlternateEmail = "deeps_1984@yahoo.com"
                                                    }
                                  };
                session.Store(deepika);
                session.SaveChanges();
                Console.WriteLine("User created");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Trying to create new database : {0}", databse);
                store.DatabaseCommands.EnsureDatabaseExists(databse);
                Console.WriteLine("Database {0} created", databse);
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
            var store = new DocumentStore
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
            store.Initialize();
            return store;
        }

        public static GeneratedPassword GeneratePassword()
        {
            var password = RandomPasswordGenerator.Generate(8);
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
