using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannSTFCTools.Util
{
    public class StfcObjectUser
    {

        public class Officer
        {
            public string Name { get; set; } = String.Empty;
            public int Level { get; set; } = 1;

            public override string ToString()
            {
                return $"Officer: {Name} | Level: {Level}";
            }

            public static List<Officer> JsonListToClasses(string json)
            {
                List<Officer> returnList = new List<Officer>();

                return returnList;
            }
        }
                
        public class Ship
        {
            public string Name { get; set; }
            public int Level { get; set; }
            public override string ToString()
            {
                return $"Ship: {Name} | Level: {Level}";
            }
            public static List<Ship> JsonListToClasses(string json)
            {
                List<Ship> returnList = new List<Ship>();

                return returnList;
            }
        }
    }
}
