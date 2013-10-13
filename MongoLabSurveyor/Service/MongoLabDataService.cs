using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoLabSurveyor.Contracts;
using MongoLabSurveyor.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.IO;

namespace MongoLabSurveyor.Service
{
    public class MongoLabDataService : IMongoLabDataService
    {
        private readonly ISettingsStore settingsStore;
        private const string BaseServiceUrl = "https://api.mongolab.com/api/1/"; 
        
        private readonly HttpClient client;

        public MongoLabDataService(ISettingsStore settingsStore)
        {
            this.settingsStore = settingsStore;
            client = new HttpClient();
        }

        public async Task<string[]> GetDatabases()
        {
            var ServiceUrl = String.Format("{0}/databases?apiKey={1}", BaseServiceUrl, settingsStore.ApiKey);

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
            var ServiceUrl = String.Format("{0}/databases/{1}/runCommand?apiKey={2}", BaseServiceUrl, db, settingsStore.ApiKey);
            var response = await client.PostAsync(ServiceUrl, new StringContent("{ \"dbStats\": 1, \"scale\": 1024 }", Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var jsonSerializer = new JsonSerializer();

            using (var bson = new JsonTextReader(new StringReader(content)))
            {
                return jsonSerializer.Deserialize<DbStatsResponse>(bson);
            }
        }

        public async Task<RepairDatabaseResponse> SendRepairDatabase(string db)
        {
            var ServiceUrl = String.Format("{0}/databases/{1}/runCommand?apiKey={2}", BaseServiceUrl, db, settingsStore.ApiKey);
            var response = await client.PostAsync(ServiceUrl, new StringContent("{ \"repairDatabase\": 1 }", Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var jsonSerializer = new JsonSerializer();

            using (var bson = new JsonTextReader(new StringReader(content)))
            {
                return jsonSerializer.Deserialize<RepairDatabaseResponse>(bson);
            }
        }
    }
}
