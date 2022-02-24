using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MicMute
{
    public class Config
    {
        public static Settings Settings { get; set; }
        private const string SettingsKey = "settings";
        private const string FileName = "appsettings.json";
        private static readonly string Path = System.IO.Path.Combine(AppContext.BaseDirectory, FileName);
        private static Dictionary<string, object> _appsettings;

        public static void Build()
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Dispose();
                _appsettings = new Dictionary<string, object>();
                Settings = new Settings();
                _appsettings[SettingsKey] = Settings;
                Save();
            }
            else
            {
                try
                {
                    _appsettings = JObject.Parse(File.ReadAllText(Path)).ToObject<Dictionary<string,object>>();
                    var jObject=_appsettings?[SettingsKey] as JObject;
                    Settings = jObject?.ToObject<Settings>();
                }
                catch (Exception )
                {
                    _appsettings = new Dictionary<string, object>();
                    Settings = new Settings();
                    _appsettings[SettingsKey] = Settings;
                    Save();
                }
                
            }

        }

        public static void Save()
        {
            if (_appsettings == null) return;
            if (Settings != null) _appsettings[SettingsKey] = Settings;
            File.WriteAllText(Path, JsonConvert.SerializeObject(_appsettings));
        }
    }

    public class Settings
    {
        public HashSet<int> Keys { get; set; }
    }
}