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
    public class MusiqueController : ApiController
    {
        //this path should be replace with the good one on my own server
        private const string PATH = "C:\\Users\\BOSSEE\\Music";

        // GET: api/Musique
        public IEnumerable<string> Get()
        {
            MusiqueService musiqueService = new MusiqueService();
            
            List<string> musiquesName = new List<string>();
            string[] dirs = Directory.GetFiles(PATH, "*");
            foreach (string file in dirs)
            {
                string name = musiqueService.getMusiqueName(file);
                if (name != null)
                {
                    musiquesName.Add(name);
                }
            }

            return musiquesName;
        }

        // GET: api/Musique/{name}
        public Musique Get(string name)
        {
            MusiqueService musiqueService = new MusiqueService();

            return musiqueService.getMusique(PATH+"\\"+name);
        }

        // POST: api/Musique
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Musique/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Musique/5
        public void Delete(int id)
        {
        }
    }
}
