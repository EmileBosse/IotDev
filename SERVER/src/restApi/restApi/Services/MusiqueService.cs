using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using restApi.Models;

namespace restApi.Services
{
    public class MusiqueService
    {
        public MusiqueService() { }

        public string getMusiqueName(string path)
        {
            return path.Split('\\')[path.Split('\\').Length - 1];
        }

        public Musique getMusique(string path)
        {
            try
            {
                Musique musique = new Musique();
                musique.fromFile(path);
                return musique;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}