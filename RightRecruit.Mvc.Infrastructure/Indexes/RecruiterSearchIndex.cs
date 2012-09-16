using System.Linq;
using Raven.Client.Indexes;
using RightRecruit.Domain;

namespace RightRecruit.Mvc.Infrastructure.Indexes
{
    public class RecruiterSearchIndex : AbstractIndexCreationTask<Recruiter>
    {
        public RecruiterSearchIndex()
        {
            Map = recruiters => from recruiter in recruiters
                                select new
                                           {
                                               Name = recruiter.NameDetail.FirstName + " " + recruiter.NameDetail.LastName + " " + recruiter.NameDetail.NickName + " " + recruiter.Username + " ",
                                               recruiter.Database
                                           };
        }
    }
}