using QRCoder;
using System.Drawing;

namespace GeoPetAPI.Services
{
    public static class QrCodeGenerator
    {
        // ref -> "https://balta.io/blog/aspnet-qrcode"
        public static Bitmap GenerateImage(string url)
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator(); 
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q); 
            QRCode qrCode = new QRCode(qrCodeData); 
            Bitmap qrCodeImage = qrCode.GetGraphic(3);
            return qrCodeImage;
        }

        public static byte[] GenerateByteArray(string url)
        {
            var image = GenerateImage(url);
            return ImageToByte(image);
        }

        private static byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }
}
