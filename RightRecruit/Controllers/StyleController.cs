using System.Linq;
using RightRecruit.Mvc.Infrastructure.Controllers;
using RightRecruit.Mvc.Infrastructure.Infrastructure;

namespace RightRecruit.Controllers
{
    public class StyleController : AbstractController
    {
        public string Css()
        {
            Response.ContentType = "text/css";
            return dotless.Core.Less.Parse(ThemeBuilder.Apply(Request.Url.Host, UnitOfWork, Server.MapPath("/Content/styles.less")));
        }
    }

    internal static class ThemeBuilder
    {
        public static string Apply(string domain, IUnitOfWork unitOfWork, string lessPath)
        {
            var css = System.IO.File.ReadAllText(lessPath);

            if (!string.IsNullOrEmpty(domain))
            {
                var agency = unitOfWork.DocumentSession.Query<Domain.Agency>().SingleOrDefault(a => a.Domain == domain);
                if (agency != null)
                {
                    var theme = agency.Branding.Theme;
                    css = css
                        .ApplyBasicColor(theme.BasicColor)
                        .ApplyMildColor(theme.MidColor)
                        .ApplyBoldColor(theme.BoldColor)
                        .ApplyControlBorderColor(theme.ControlBorderColor);
                }
            }
            return css;
        }
    }

    internal static class ThemeExtensions
    {
        private const string BasicWithColor = "@metro-blue: #0094cd;";
        private const string BasicFormat = "@metro-blue: {0};";
        private const string MildWithColor = "@metro-mild-blue: #0088cc;";
        private const string MildFormat = "@metro-mild-blue: {0};";
        private const string BoldWithColor = "@metro-serious-blue: #006393;";
        private const string BoldFormat = "@metro-serious-blue: {0};";
        private const string ControlBorderWithColor = "@control-select-border-color: #0994CD;";
        private const string ControlBorderFormat = "@control-select-border-color: {0};";

        public static string ApplyBasicColor(this string css, string basic)
        {
            if (string.IsNullOrEmpty(basic))
                return css;
            return css.Replace(BasicWithColor, string.Format(BasicFormat, basic));
        }

        public static string ApplyMildColor(this string css, string mild)
        {
            if (string.IsNullOrEmpty(mild))
                return css;
            return css.Replace(MildWithColor, string.Format(MildFormat, mild));
        }

        public static string ApplyBoldColor(this string css, string bold)
        {
            if (string.IsNullOrEmpty(bold))
                return css;
            return css.Replace(BoldWithColor, string.Format(BoldFormat, bold));
        }

        public static string ApplyControlBorderColor(this string css, string border)
        {
            if (string.IsNullOrEmpty(border))
                return css;
            return css.Replace(ControlBorderWithColor, string.Format(ControlBorderFormat, border));
        }
    }
}
