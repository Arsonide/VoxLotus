using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Windows.Forms;

namespace VoxLotus
{
    public class ConfigurationEntry
    {
        protected const string emptyString = "";
        protected const string defaultTag = "Default";

        [DefaultValue(ConfigEntryType.Unknown)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "EntryType", DefaultValueHandling = DefaultValueHandling.Populate)]
        public ConfigEntryType EntryType = ConfigEntryType.Unknown;

        [DefaultValue("EntryName")]
        [JsonProperty(PropertyName = "EntryName", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string EntryName = "EntryName";

        [DefaultValue(emptyString)]
        [JsonProperty(PropertyName = "EntryDisplay", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string EntryDisplay = emptyString;

        [DefaultValue(emptyString)]
        [JsonProperty(PropertyName = "EntryPronunciation", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string EntryPronunciation = emptyString;

        [DefaultValue("a")]
        [JsonProperty(PropertyName = "EntryPrefix", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string EntryPrefix = "a";

        [DefaultValue(CheckState.Checked)]
        [JsonProperty(PropertyName = "EntryInterest", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState EntryCheckState = CheckState.Checked;

        [DefaultValue(defaultTag)]
        [JsonProperty(PropertyName = "TediousTag", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string TediousTag = defaultTag;

        public string GetDisplay()
        {
            return !string.IsNullOrWhiteSpace(EntryDisplay) ? EntryDisplay : EntryName;
        }

        public string GetPronunciation()
        {
            return !string.IsNullOrWhiteSpace(EntryPronunciation) ? EntryPronunciation : EntryName;
        }
    }
}
