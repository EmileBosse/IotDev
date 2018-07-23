using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restApi.Models
{
    public class Station
    {
        public int id { get; set; }
        public List<Sensor> sensors { get; set; }
        public bool isActive { get; set; }
        public float voltage { get; set; }
        public string name { get; set; }
        public Position location { get; set; }

        public Station()
        {

        }
    }
}