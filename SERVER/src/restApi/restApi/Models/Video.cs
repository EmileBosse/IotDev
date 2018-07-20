using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restApi.Models
{
    public class Video
    {
        public byte[] vid { get; set; }
        public string name { get; set; }
        public string duree { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public Video() { }

        public void fromFile(string path)
        {
            this.type = path.Split('.')[path.Split('.').Length - 1];
            if (isVideo(this.type))
            {

            }
            else throw new Exception("The file we received is not a video file.");
        }

        private bool isVideo(string extension)
        {
            return (extension.Contains("mp4") || extension.Contains("MP4"));
        }
    }
}