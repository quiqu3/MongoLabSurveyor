using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MongoLabSurveyor.Model;

namespace MongoLabSurveyor.Contracts
{
    interface IMongoLabDataService
    {        
        Task<string[]> GetDatabases();
        Task<List<Collection>> GetCollections(string db);
        Task<int> GetDocumentsCount(string db, string collection);
    }
}
