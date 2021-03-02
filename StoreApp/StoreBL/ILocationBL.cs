using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface ILocationBL
    {
        List<Location> GetLocations();
        void AddLocation(Location newLocation);
        void DeleteLocation(Location newLocation);
        Location GetLocationById(int locId);
    }
}