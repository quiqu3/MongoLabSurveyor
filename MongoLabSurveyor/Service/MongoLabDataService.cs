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
        string key = "";
        private const string BaseServiceUrl = "https://api.mongolab.com/api/1/"; 
        
        private readonly HttpClient client;

        public MongoLabDataService()
        {
            client = new HttpClient();
        }

        public async Task<string[]> GetDatabases()
        {
            var ServiceUrl = String.Format("{0}/databases?apiKey={1}", BaseServiceUrl, key);

            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(ServiceUrl));
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var jsonSerializer = new JsonSerializer();
            string[] array;

            using (var bson = new JsonTextReader(new StringReader(result)))
            {
                array = jsonSerializer.Deserialize<string[]>(bson);
            }

            return array;
        }

        public async Task<DbStatsResponse> GetDbStats(string db)
        {

            var ServiceUrl = String.Format("{0}/databases/{1}/runCommand?apiKey={2}", BaseServiceUrl, db, key);
            var response = await client.PostAsync(ServiceUrl, new StringContent("{ \"dbStats\": 1, \"scale\": 1024 }", Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var jsonSerializer = new JsonSerializer();

            using (var bson = new JsonTextReader(new StringReader(content)))
            {
                return jsonSerializer.Deserialize<DbStatsResponse>(bson);
            }
        }

        public async Task<List<Collection>> GetCollections(string db)
        {
            var dbs = new List<Collection>();

            var ServiceUrl = String.Format("{0}/databases/{1}/collections?apiKey={2}", BaseServiceUrl, db, key);

            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(ServiceUrl));
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var jsonSerializer = new JsonSerializer();
            string[] array;

            using (var bson = new JsonTextReader(new StringReader(result)))
            {
                array = jsonSerializer.Deserialize<string[]>(bson);
            }

            array.ToList().ForEach(colection => dbs.Add(new Collection { Name = colection }));

            return dbs;
        }

        public async Task<int> GetDocumentsCount(string db, string collection)
        {
            var dbs = new List<Collection>();

            var ServiceUrl = String.Format("{0}/databases/{1}/collections/{2}?apiKey={3}&c=true", BaseServiceUrl, db, collection, key);

            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(ServiceUrl));
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var jsonSerializer = new JsonSerializer();
            int array;

            using (var bson = new JsonTextReader(new StringReader(result)))
            {
                array = jsonSerializer.Deserialize<int>(bson);
            }

            return array;
        }

       
    }
}
