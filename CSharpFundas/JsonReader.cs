using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.utilities
{
    internal class JsonReader
    {


        static void Main(string[] args)
        {
            string myJsonString = File.ReadAllText("testData.json");

            var jsonObj = JToken.Parse(myJsonString);

            Console.WriteLine(jsonObj.SelectToken("Username").Value<string>());

            Console.ReadKey();


        }
    }
}
