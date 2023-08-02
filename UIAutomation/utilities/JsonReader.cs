using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UIAutomation.utilities
{
    internal class JsonReader
    {
        public JsonReader()
        {

        }

        public string extractData(string tokenName)
        {
            string myJsonString = File.ReadAllText("utilities/testData.json");

            var jsonObj = JToken.Parse(myJsonString);

            return jsonObj.SelectToken(tokenName).Value<string>();

        }
    }
}
