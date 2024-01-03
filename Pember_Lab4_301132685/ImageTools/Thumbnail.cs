using GrapeCity.Documents.Drawing;
using GrapeCity.Documents.Imaging;
using GrapeCity.Documents.Text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pember_Lab4_301132685.ImageTools
{
    class Thumbnail
    {
        /// <summary>
        /// Ref. https://developer.mescius.com/blogs/create-a-thumbnail-image-using-documents-for-imaging
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string GetConvertedImage(byte[] stream)
        {
            using (var originalBitmap = new GcBitmap())
            {
                originalBitmap.Load(stream);

                // Add watermark
                var watermarkedBitmap = new GcBitmap();
                watermarkedBitmap.Load(stream);

                using (var graphics = originalBitmap.CreateGraphics(Color.White))
                {
                    graphics.DrawImage(
                        watermarkedBitmap,
                        new RectangleF(0, 0, originalBitmap.Width, originalBitmap.Height),
                        null,
                        ImageAlign.Default
                    );

                    graphics.DrawString("DOCUMENT", new TextFormat
                    {
                        FontSize = 22,
                        ForeColor = Color.FromArgb(128, Color.Yellow),
                        Font = FontCollection.SystemFonts.DefaultFont
                    },
                    new RectangleF(0, 0, originalBitmap.Width, originalBitmap.Height),
                    TextAlignment.Center,
                    ParagraphAlignment.Center,
                    false);
                }

                // Convert to grayscale
                originalBitmap.ApplyEffect(GrayscaleEffect.Get(GrayscaleStandard.BT601));

                // Resize to thumbnail
                var resizedImage = originalBitmap.Resize(100, 100, InterpolationMode.NearestNeighbor);

                return GetBase64(resizedImage);
            }
        }
        private static string GetBase64(GcBitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.SaveAsPng(memoryStream);
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}