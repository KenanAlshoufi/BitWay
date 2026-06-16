using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Windows;

namespace BankSystemBusinessLayar.QR
{
    public class IDQRCoder
    {

        public static bool CreateFolderIfDoesNotExist(string Path)
        {
            if (!Directory.Exists(Path))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(Path);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;
        }
        public static string QR(string code)
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrImage = qrCode.GetGraphic(20);

            if (!CreateFolderIfDoesNotExist(@"D:\BitWay images\QR\"))
            {
                return "";
            }

            string Path = @"D:\BitWay images\QR\" + code + ".png";

            qrImage.Save(Path);
            return Path;
        }

    }
}
