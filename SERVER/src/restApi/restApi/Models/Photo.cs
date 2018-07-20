using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace restApi.Models
{
    public class Photo
    {
        public byte[] img { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }

        public Photo() { }

        public void fromFile(string path)
        {
            if (isImage(path))
            {
                Image img = Image.FromFile(path, true);
                this.img = ImageToByteArray(img);
                this.path = path;
                string[] chemin = path.Split('/');
                if (chemin.Length > 1)
                {
                    this.name = chemin[chemin.Length - 1];
                }
                else
                {
                    string[] chemin2 = path.Split('\\');
                    this.name = chemin2[chemin2.Length - 1];
                }
                string[] lastDot = path.Split('.');
                this.type = lastDot[lastDot.Length - 1];
            }
            else throw new Exception("The file we received is not a picture");
        }

        private bool isImage(string path)
        {
            return (path.Contains("BMP") || path.Contains("GIF") || path.Contains("JPEG") ||
                path.Contains("JPG") || path.Contains("PNG") || path.Contains("TIFF") ||
                path.Contains("bmp") || path.Contains("gif") || path.Contains("jpeg") ||
                path.Contains("jpg") || path.Contains("png") || path.Contains("tiff"));
        }

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}