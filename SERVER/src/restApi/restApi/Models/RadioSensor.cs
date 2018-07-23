using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restApi.Models
{
    public class RadioSensor : Sensor
    {
        public float range { get; set; }

        public RadioSensor()
        {

        }
    }
}