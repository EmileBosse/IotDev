using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using restApi.Models;

namespace restApi.Services
{
    public class StationService
    {
        public StationService() { }

        //get all station
        public List<Station> getStation()
        {
            return null;
        }

        //get one station
        public Station getStation(int id)
        {
            return null;
        }

        //get all the sensor for a station
        public List<Sensor> getSensorForStation(int idStation)
        {
            return null;
        }

        //get one sensor for a station
        public Sensor getSensorForStation(int idStation, int idSensor)
        {
            return null;
        }
    }
}