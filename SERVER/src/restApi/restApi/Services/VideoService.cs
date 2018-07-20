using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using restApi.Models;

namespace restApi.Services
{
    public class VideoService
    {
        public VideoService() { }

        public string getVideoName(string path)
        {
            return path.Split('\\')[path.Split('\\').Length - 1];
        }

        public Video getVideo(string path)
        {
            try
            {
                Video vid = new Video();
                vid.fromFile(path);
                return vid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}