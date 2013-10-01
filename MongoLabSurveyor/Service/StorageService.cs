namespace MongoLabSurveyor.Service
{
    using System.IO.IsolatedStorage;
    using MongoLabSurveyor.Contracts;

    public class StorageService : IStorageService
    {
        public void SaveSetting(string key, string data)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            // txtInput is a TextBox defined in XAML.
            if (!settings.Contains(key))
            {
                settings.Add(key, data);
            }
            else
            {
                settings[key] = data;
            }
            settings.Save();

        }

        public string ReadSetting(string key)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                return IsolatedStorageSettings.ApplicationSettings[key] as string;
            }

            return string.Empty;
        }
    }
}
