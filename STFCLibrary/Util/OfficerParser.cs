using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static STFCLibrary.JsonClasses.Officer;

namespace STFCLibrary.Util
{
    public class OfficerParser
    {


        /// <summary>
        /// Compresses a list of officers to sharing with other people.
        /// </summary>
        /// <param name="officers">Strongly typed list of officers</param>
        /// <returns>String usable for sharing - small enough to share in Discord.</returns>
        public static string CompressOfficerList(List<OfficerStatus> officerList)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(1500);

            string stringToCompress = String.Join(';', officerList);

            var task = Compression.ToBrotliAsync(stringToCompress, System.IO.Compression.CompressionLevel.SmallestSize);

            task.Wait();

            return task.Result.Result.Value;
        }

        /// <summary>
        /// Decompresses a list of officers.
        /// </summary>
        /// <param name="compressedString"></param>
        /// <returns></returns>
        public static List<OfficerStatus> DecompressOfficerList(string compressedString)
        {
            var task = Compression.FromBrotliAsync(compressedString);
            task.Wait();
            List<OfficerStatus> officerList = new List<OfficerStatus>();

            foreach(string off in task.Result.Split(';'))
            {
                string[] offData = off.Split('|');


                officerList.Add(new OfficerStatus()
                {
                    OfficerName = offData[0],
                    OfficerLevel = Convert.ToInt32(offData[1])
                });
            }

            return officerList;
        }

        public class OfficerStatus
        {
            [JsonProperty("OfficerName")]
            public string OfficerName { get; set; }

            /// <summary>
            /// Zero means they do not have that officer.
            /// Any positive number indicates the level.
            /// -1 means they have that officer but don't know the level.
            /// </summary>
            [JsonProperty("Level")]
            public int OfficerLevel { get; set; } = 0;

            public override string ToString()
            {
                return $"{OfficerName}|{OfficerLevel}";
            }

            /// <summary>
            /// This will create an empty json file with all officers for a user to enter for future parsing.
            /// </summary>
            /// <param name="fileName"></param>
            public static void CraeteEmptyJsonOfficerList(string fileName, List<JsonClasses.Officer.JsonOfficer> officerList)
            {
                List<OfficerStatus> nameLevelList = new List<OfficerStatus>();
                foreach(var off in officerList)
                {
                    nameLevelList.Add(new OfficerStatus() { OfficerName = off.Name });
                }
            }
        }
    }
}
