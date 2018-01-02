using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace VoxLotus
{
    public class ConfigurationManager
    {
        #region Statics

        protected const string file = "config.json";

        protected static ConfigurationManager _instance;

        public static ConfigurationManager Instance
        {
            get
            {
                if (_instance == null)
                    LoadInstance();

                return _instance;
            }
        }

        protected static string InstanceJson => JsonConvert.SerializeObject(_instance, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        public static void LoadInstance()
        {
            string loadedFile;

            try
            {
                loadedFile = File.ReadAllText($"{Environment.CurrentDirectory}\\{file}");
                _instance = JsonConvert.DeserializeObject<ConfigurationManager>(loadedFile);
            }
            catch
            {
                loadedFile = string.Empty;
                _instance = new ConfigurationManager();
            }

            SaveInstanceIfChanged(loadedFile);

            _instance.Initialize();
        }

        public static void SaveInstance()
        {
            File.WriteAllText($"{Environment.CurrentDirectory}\\{file}", InstanceJson);
        }

        protected static void SaveInstanceIfChanged(string original)
        {
            string json = InstanceJson;

            if (json != original)
                File.WriteAllText($"{Environment.CurrentDirectory}\\{file}", json);
        }

        #endregion

        [JsonProperty(PropertyName = "Settings", DefaultValueHandling = DefaultValueHandling.Include, NullValueHandling = NullValueHandling.Ignore, ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public ConfigurationSettings Settings = new ConfigurationSettings();

        [JsonProperty(PropertyName = "Entries", DefaultValueHandling = DefaultValueHandling.Include, NullValueHandling = NullValueHandling.Ignore, ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public List<ConfigurationEntry> Entries = new List<ConfigurationEntry>();

        [JsonProperty(PropertyName = "TediousMissions", DefaultValueHandling = DefaultValueHandling.Include, NullValueHandling = NullValueHandling.Ignore, ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public Dictionary<string, List<string>> TediousMissions = new Dictionary<string, List<string>>();

        [JsonProperty(PropertyName = "Pluralizations", DefaultValueHandling = DefaultValueHandling.Include, NullValueHandling = NullValueHandling.Ignore, ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public Dictionary<string, string> Pluralizations = new Dictionary<string, string>();

        [JsonIgnore]
        protected readonly Dictionary<ConfigEntryType, List<ConfigurationEntry>> entriesByType = new Dictionary<ConfigEntryType, List<ConfigurationEntry>>();

        [JsonIgnore]
        protected readonly Dictionary<string, ConfigurationEntry> entriesByName = new Dictionary<string, ConfigurationEntry>();

        protected void Initialize()
        {
            entriesByType.Clear();
            entriesByName.Clear();

            foreach(ConfigurationEntry entry in Entries)
            {
                if (!entriesByType.ContainsKey(entry.EntryType) || entriesByType[entry.EntryType] == null)
                    entriesByType[entry.EntryType] = new List<ConfigurationEntry>();

                entriesByType[entry.EntryType].Add(entry);
                entriesByName[entry.EntryName] = entry;
            }

            foreach(KeyValuePair<string, string> pair in Pluralizations)
            {
                Utilities.AddPluralization(pair.Key, pair.Value);
            }
        }

        public bool HasEntriesOfType(ConfigEntryType type)
        {
            if (entriesByType == null || entriesByType.Count <= 0)
                return false;

            return entriesByType.ContainsKey(type) && entriesByType[type].Count > 0;
        }

        public List<ConfigurationEntry> GetEntriesOfType(ConfigEntryType type)
        {
            entriesByType.TryGetValue(type, out List<ConfigurationEntry> entries);
            return entries;
        }

        public bool HasEntryName(string entryName)
        {
            if (entriesByName == null || entriesByName.Count <= 0)
                return false;

            return entriesByName.ContainsKey(entryName);
        }

        public ConfigurationEntry GetEntryByName(string name)
        {
            entriesByName.TryGetValue(name, out ConfigurationEntry entry);
            return entry;
        }

        public List<string> GetTediousMissions(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                tag = "Default";

            if (TediousMissions.ContainsKey(tag))
                return TediousMissions[tag];

            if (TediousMissions.Count <= 0 || !TediousMissions.ContainsKey("Default"))
                TediousMissions.Add("Default", new List<string>());

            return TediousMissions["Default"];
        }
    }
}
 