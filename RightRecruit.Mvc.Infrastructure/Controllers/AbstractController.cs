using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RightRecruit.Domain;
using RightRecruit.Mvc.Infrastructure.Infrastructure;

namespace RightRecruit.Mvc.Infrastructure.Controllers
{
    public class AbstractController : Controller
    {
        public HttpSessionStateBase HttpSessionStateBase
        {
            get { return Session; }
        }

        public IUnitOfWork UnitOfWork { get; set; }
        public ICurrentUserProvider CurrentUserProvider { get; set; }

        protected string GetAttachmentString(AttachmentReference attachmentReference, bool useBase64 = false)
        {
            var attachment = UnitOfWork.DocumentSession.Advanced.DocumentStore.DatabaseCommands.GetAttachment(attachmentReference.AttachmentId);
            if (attachment != null && attachment.Data != null)
            {
                if (useBase64)
                {
                    using (var ms = new MemoryStream())
                    {
                        var stream = attachment.Data();
                        stream.CopyTo(ms);
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
                
                using (var streamReader = new StreamReader(attachment.Data(), Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
            }

            return string.Empty;
        }

        static public string EncodeTo64(string toEncode)
        {
            var toEncodeAsBytes = System.Text.Encoding.ASCII.GetBytes(toEncode);
            var returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        protected void LoadUser(string userId)
        {

        }
    }
}