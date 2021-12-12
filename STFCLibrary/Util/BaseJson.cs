using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFCLibrary.Util;
public class BaseJson
{
    public class STFCBase<T>
    {
        public string Name { get; set; } = String.Empty;
        public int Level { get; set; } = 1;

        public override string ToString()
        {
            return $"{typeof(T).FullName} Name: {Name} | Level: {Level}";
        }

        public static List<T> JsonListToClasses(string json)
        {
            List<T> returnList = new List<T>();

            return returnList;
        }
    }
}
