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
        public static MySettings Settings { get; set; }

        public static void Build()
        {
            Settings = JsonConvert.DeserializeObject<MySettings>(MicMute.Settings.Default.Keys)??new MySettings();
        }

        public static void Save()
        {
            MicMute.Settings.Default.Keys = JsonConvert.SerializeObject(Settings);
            MicMute.Settings.Default.Save();
        }
    }

    public class MySettings
    {
        public HashSet<int> Keys { get; set; }
    }
}