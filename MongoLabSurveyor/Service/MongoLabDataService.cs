using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoLabSurveyor.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.IO;

namespace MongoLabSurveyor.Service
{
    public class MongoLabDataService
    {
        private const string ServiceUrl = "https://api.mongolab.com/api/1/databases?apiKey=";
        private readonly HttpClient client;
        public MongoLabDataService()
        {
            client = new HttpClient();
        }
        public async Task<string[]> GetDatabases()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(ServiceUrl));
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var jsonSerializer = new JsonSerializer();
            string[] dict;

            using (var bson = new JsonTextReader(new StringReader(result)))
            {
                dict = jsonSerializer.Deserialize<string[]>(bson);
            }

            return dict;
        }
    }
}
