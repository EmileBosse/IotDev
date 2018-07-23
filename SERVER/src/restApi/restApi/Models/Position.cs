using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restApi.Models
{
    public class Position
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
        public Position() { }
        public Position(double lon, double lat) {
            this.longitude = lon;
            this.latitude = lat;
        }
    }
}