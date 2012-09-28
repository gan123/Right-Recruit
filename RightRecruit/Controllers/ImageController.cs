using System.Drawing;
using System.Web.Mvc;
using ImageResizer;
using RightRecruit.Helpers;

namespace RightRecruit.Controllers
{
    public class ImagesController : Controller
    {
        public ActionResult Render(string file)
        {
            var fullFilePath = GetFullFilePath(file);
            if (ImageFileNotAvailable(fullFilePath))
                return Instantiate404ErrorResult(file);
            return new ImageFileResult(fullFilePath);
        }

        public ActionResult RenderWithResize(int width, int height, string file)
        {
            var fullFilePath = GetFullFilePath(file);
            if (ImageFileNotAvailable(fullFilePath))
                return Instantiate404ErrorResult(file);
            var resizeSettings = InstantiateResizeSettings(width, height);
            var resizedImage = ImageBuilder.Current.Build(fullFilePath, resizeSettings);
            return new DynamicImageResult(file, resizedImage.ToByteArray());
        }

        public ActionResult RenderWithResizeAndWatermark(int width, int height, string file)
        {
            var fullFilePath = GetFullFilePath(file);
            if (ImageFileNotAvailable(fullFilePath))
                return Instantiate404ErrorResult(file);
            var resizeSettings = InstantiateResizeSettings(width, height);
            var resizedImage = ImageBuilder.Current.Build(fullFilePath, resizeSettings);
            var watermarkFullFilePath = GetFullFilePath("Watermark.png");
            resizedImage = AddWatermark(resizedImage,
                watermarkFullFilePath, new Point(0, 0));
            return new DynamicImageResult(file, resizedImage.ToByteArray());
        }

        private string GetFullFilePath(string file)
        {
            return string.Format("{0}/{1}", Server.MapPath("~/Content/Images"), file);
        }

        private bool ImageFileNotAvailable(string fullFilePath)
        {
            return System.IO.File.Exists(fullFilePath);
        }

        private HttpNotFoundResult Instantiate404ErrorResult(string file)
        {
            return new HttpNotFoundResult(
                string.Format("The file {0} does not exist.", file));
        }

        private ResizeSettings InstantiateResizeSettings(int width, int height)
        {
            var queryString = string.Format(
                "maxwidth={0}&maxheight={1}&quality=90",
                width, height);
            return new ResizeSettings(queryString);
        }

        private Bitmap AddWatermark(Bitmap image, string watermarkFullFilePath, Point watermarkLocation)
        {
            using (var watermark = Image.FromFile(watermarkFullFilePath))
            {
                var watermarkToUse = watermark;
                if (watermark.Width > image.Width || watermark.Height > image.Height)
                {
                    var resizeSettings = InstantiateResizeSettings(image.Width,
                        image.Height);
                    watermarkToUse = ImageBuilder.Current.Build(watermarkFullFilePath,
                        resizeSettings);
                }
                using (var graphics = Graphics.FromImage(image))
                {
                    graphics.DrawImage(watermarkToUse, watermarkLocation);
                }
            }
            return image;
        }
    }
}
