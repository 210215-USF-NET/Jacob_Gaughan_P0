using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class LocationBL : ILocationBL
    {
        private ILocationRepository _repo;
        public LocationBL(ILocationRepository repo){
            _repo = repo;
        }

        public void AddLocation(Location newLocation)
        {
            _repo.AddLocation(newLocation);
        }

        public List<Location> GetLocations()
        {
            // TODO add Business Logic
            return _repo.GetLocations();
        }
        public Location GetLocationById(int locId){
            return _repo.GetLocationById(locId);
        }
    }
}
