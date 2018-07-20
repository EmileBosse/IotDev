using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restApi.Models
{
    public class Musique
    {
        public byte[] song { get; set; }
        public byte[] imageCover { get; set; }
        public string name { get; set; }
        public string artistName { get; set; }
        public string title { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public Musique() { }

        public void fromFile(string path)
        {
            this.type = path.Split('.')[path.Split('.').Length - 1];
            if (isMusique(this.type))
            {

            }
            else throw new Exception("The file we received is not a sound file");
        }

        private bool isMusique(string extension)
        {
            return (extension.Contains("mp3") || extension.Contains("MP3"));
        }
    }
}