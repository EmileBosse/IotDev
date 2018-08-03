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
    public class PhotoController : ApiController
    {
        //this path should be replace with the good one on my own server
        private const string PATH = "C:\\Users\\EmileBosse\\Pictures";


        // GET: api/Photo
        public IEnumerable<Photo> Get()
        {
            PhotoService photoService = new PhotoService();

            List<Photo> photos = new List<Photo>();
            string[] dirs = Directory.GetFiles(PATH, "*");
            foreach(string file in dirs)
            {
                Photo p = photoService.getFile(file);
                if(p != null)
                {
                    photos.Add(p);
                }
            }
            Console.WriteLine("************************************\n"+
                              "Nous avons "+dirs.Length+" fichiers d'image\n"+
                              "Ce qui nous donne "+photos.Count+" photos.");
            return photos;
        }

        // GET: api/Photo/{name}
        public Photo Get(string name)
        {
            PhotoService photoService = new PhotoService();

            Console.WriteLine("Voici le name:"+name+"  |  Voici le Path complet:"+ PATH + "\\" + name);
            return photoService.getFile(PATH + "\\" + name);
        }

        // POST: api/Photo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Photo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Photo/5
        public void Delete(int id)
        {
        }
    }
}
