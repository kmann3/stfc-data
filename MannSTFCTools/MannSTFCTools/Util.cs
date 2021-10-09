using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannSTFCTools
{
    public class Util<T>
    {
        /// <summary>
        /// Given a folder, it will parse the folder for all officers
        /// </summary>
        /// <param name="officerFolder">Location to officers folder. It'll proably be something like 'STFCCommunity-data.git\officers'.</param>
        /// <returns>Strongly typed list of officers given a folder.</returns>
        /// <exception cref="Exception">Either file has no data, isn't in the expected format, or lacks an officer name -- which is the minimum.</exception>
        public static List<T> GetListFromJsonFolder(string folder)
        {
            List<T> returnList = new();

            foreach (string f in Directory.GetFiles(folder))
            {

                Console.WriteLine($"Loading '{f}");
                string jsonData = File.ReadAllText(f) ?? throw new Exception($"Trouble with file, no data? Filename: {f}");
                T item = JsonConvert.DeserializeObject<T>(jsonData) ?? throw new Exception($"ITem is empty. Perhaps this is empty? JSON Data: '{jsonData}'");
                returnList.Add(item);
                if (item is MannSTFCTools.JsonClasses.Ship.JsonShip)
                {
                    JsonClasses.Ship.JsonShip? ship = item as JsonClasses.Ship.JsonShip;
                    if (String.IsNullOrWhiteSpace(ship.Name))
                    {
                        throw new NotImplementedException();
                    }
                    
                }
                
            }

            return returnList;
        }

        public interface JsonBase
        {
            public string Name { get; }
        }
    }
}
