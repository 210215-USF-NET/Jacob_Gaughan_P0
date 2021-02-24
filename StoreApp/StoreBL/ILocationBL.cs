using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface ILocationBL
    {
        List<Location> GetLocations();
    }
}