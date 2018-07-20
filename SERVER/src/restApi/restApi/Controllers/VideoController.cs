using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using restApi.Models;
using restApi.Services;

namespace restApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VideoController : ApiController
    {
        //this path should be replace with the good one on my own server
        private const string PATH = "C:\\Users\\BOSSEE\\Videos";

        // GET: api/Video
        public IEnumerable<string> Get()
        {
            VideoService videoService = new VideoService();

            List<string> videosName = new List<string>();
            string[] dirs = Directory.GetFiles(PATH, "*");
            foreach (string file in dirs)
            {
                string name = videoService.getVideoName(file);
                if (name != null)
                {
                    videosName.Add(name);
                }
            }

            return videosName;
        }

        // GET: api/Video/{name}
        public Video Get(string name)
        {
            VideoService videoService = new VideoService();

            return videoService.getVideo(PATH+"\\"+name);
        }

        // POST: api/Video
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Video/5
        public void Delete(int id)
        {
        }
    }
}
