using System.Collections.Generic;
using StoreModels;
using System.IO;
using System.Text.Json;
using System;

namespace StoreDL
{
    public class LocationRepoFile : ILocationRepository
    {
        private string jsonString;
        private string filePath = "../StoreDL/FileStorage/LocationFiles.json"; 
        public List<Location> GetLocations()
        {
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                return new List<Location>();
            }
            return JsonSerializer.Deserialize<List<Location>>(jsonString);
        }
    }
}