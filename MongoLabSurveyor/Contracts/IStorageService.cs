namespace MongoLabSurveyor.Contracts
{
    public interface IStorageService
    {
        void SaveSetting(string key, string data);
        string ReadSetting(string key);
    }
}
