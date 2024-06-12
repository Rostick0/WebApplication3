using System.Drawing.Imaging;

namespace WebApplication3.Utils
{
    public class ImageHelper
    {
        public static ImageFormat getImageFormat(string filePath)
        {
            ImageFormat imageFormat;

            switch (Path.GetExtension(filePath).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    imageFormat = ImageFormat.Jpeg;
                    break;
                case ".png":
                    imageFormat = ImageFormat.Png;
                    break;
                case ".webp":
                    imageFormat = ImageFormat.Webp;
                    break;
                case ".gif":
                    imageFormat = ImageFormat.Gif;
                    break;
                default:
                    throw new NotSupportedException("Unsupported image format");
            }

            return imageFormat;
        }
    }
}
