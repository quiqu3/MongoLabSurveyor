namespace MongoLabSurveyor.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    public interface IMongoLabDataService
    {        
        Task<string[]> GetDatabases();
        Task<List<Collection>> GetCollections(string db);
        Task<int> GetDocumentsCount(string db, string collection);
    }
}
