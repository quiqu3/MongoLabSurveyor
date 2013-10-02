namespace MongoLabSurveyor.Service
{
    using System.IO.IsolatedStorage;
    using MongoLabSurveyor.Contracts;
    using System.Collections.Generic;
    using System;

    public class SettingsStore : ISettingsStore
    {
        private readonly IsolatedStorageSettings isolatedStore;

        private const string ApiKeySettingDefault = "";
        private const string ApiKeySettingKeyName = "ApiKeySetting";

        public SettingsStore()
        {
            isolatedStore = IsolatedStorageSettings.ApplicationSettings;
        }

        public string ApiKey
        {
            get { return this.GetValueOrDefault(ApiKeySettingKeyName, ApiKeySettingDefault); }
            set { this.AddOrUpdateValue(ApiKeySettingKeyName, value); }
        }

        private void AddOrUpdateValue(string key, object value)
        {
            bool valueChanged = false;

            try
            {
                if (isolatedStore[key] != value)
                {
                    isolatedStore[key] = value;
                    valueChanged = true;
                }
            }
            catch (KeyNotFoundException)
            {
                isolatedStore.Add(key, value);
                valueChanged = true;
            }
            catch (ArgumentException)
            {
                isolatedStore.Add(key, value);
                valueChanged = true;
            }

            if (valueChanged)
            {
                Save();
            }
        }

        private T GetValueOrDefault<T>(string key, T defaultValue)
        {
            T value;

            try
            {
                value = (T)isolatedStore[key];
            }
            catch (KeyNotFoundException)
            {
                value = defaultValue;
            }
            catch (ArgumentException)
            {
                value = defaultValue;
            }

            return value;
        }

        private void Save()
        {
            isolatedStore.Save();
        }
    }
}
