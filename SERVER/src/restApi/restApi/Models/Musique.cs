using System;
using System.Collections.Generic;
using System.IO;
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
                this.song = File.ReadAllBytes(path);
                //no image cover
                //this.imageCover = 
                string[] lastPart = path.Split('\\');
                string[] sp = lastPart[lastPart.Length - 1].Split('-');
                this.name = lastPart[lastPart.Length - 1];
                this.artistName = sp[0];
                this.title = sp[1];
                this.path = path;
            }
            else throw new Exception("The file we received is not a sound file");
        }

        private bool isMusique(string extension)
        {
            return (extension.Contains("mp3") || extension.Contains("MP3") || extension.Contains("wav") || extension.Contains("WAV"));
        }
    }
}