using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restApi.Models
{
    public class PressureSensor : Sensor
    {
        public float pressureValue { get; set; }
        public PressureSensor() { }

    }
}