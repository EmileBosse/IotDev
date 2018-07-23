using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using restApi.Services;
using restApi.Models;

namespace restApi.Controllers
{
    public class StationController : ApiController
    {
        // GET: api/Station
        public IEnumerable<Station> Get()
        {
            StationService stationService = new StationService();

            return stationService.getStation();
        }

        // GET: api/Station/{idStation}
        public Station Get(int id)
        {
            StationService stationService = new StationService();

            return stationService.getStation(id);
        }

        // GET: api/Station/{idStation}/Sensor
        public List<Sensor> GetSensor(int idStation)
        {
            StationService stationService = new StationService();

            return stationService.getSensorForStation(idStation);
        }

        // GET: api/Station/{idStation}/Sensor/{idSensor}
        public Sensor GetSensor(int idStation, int idSensor)
        {
            StationService stationService = new StationService();

            return stationService.getSensorForStation(idStation, idSensor);
        }

        // POST: api/Station
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Station/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Station/5
        public void Delete(int id)
        {
        }
    }
}
