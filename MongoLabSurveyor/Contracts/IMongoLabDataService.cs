namespace MongoLabSurveyor.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    public interface IMongoLabDataService
    {        
        Task<string[]> GetDatabases();        
        Task<DbStatsResponse> GetDbStats(string db);
    }
}
