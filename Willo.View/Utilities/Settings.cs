using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tapi.WebConnection;
using Windows.Storage;

namespace Willo.View.Utilities
{
    public class Settings
    {
        private const string SettingsFilename = "Settings.json";
        private Dictionary<string, object> settings = new Dictionary<string, object>();

        public Settings()
        {
            Load().Wait();
        }

        public async Task Load()
        {
            var folder = ApplicationData.Current.LocalFolder;
            var settingsFile = await folder.TryGetItemAsync(SettingsFilename) as IStorageFile;

            if (settingsFile != null)
            {
                var settingsJson = await FileIO.ReadTextAsync(settingsFile);
                settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(settingsJson);
            }
        }

        public async Task Save()
        {
            var folder = ApplicationData.Current.LocalFolder;
            var settingsFile = await folder.TryGetItemAsync(SettingsFilename) as IStorageFile;
            if(settingsFile == null)
                settingsFile = await folder.CreateFileAsync(SettingsFilename);

            var settingsJson = JsonConvert.SerializeObject(settings);
            await FileIO.WriteTextAsync(settingsFile, settingsJson);
        }

        private T? getStruct<T>(string key) where T : struct
        {
            if (settings.ContainsKey(key)) return (T)settings[key];
            else return default(T);
        }

        private T getClass<T>(string key) where T : class
        {
            if (settings.ContainsKey(key)) return (T)settings[key];
            else return default(T);
        }

        private void setValue(string key, object value)
        {
            settings[key] = value;
            Save();
        }

        public AuthorizationToken? AuthorizationToken
        {
            get { return getClass<string>("AuthorizationToken"); }
            set { setValue("AuthorizationToken", (string)value); }
        }
    }
}
