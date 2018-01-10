using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Windows.Forms;

namespace VoxLotus
{
    public class ConfigurationSettings
    {
        public const string DefaultCustomSearch = "Comma separated reward names - supports exact names, wildcards, and regular expressions.";

        protected const string defaultTag = "Default";
        protected const string defaultRelevantPrefix = "[";
        protected const string defaultRelevantSuffix = "]";

        [DefaultValue(CheckState.Unchecked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "PopUpInGame", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState PopUpInGame = CheckState.Unchecked;

        [DefaultValue(CheckState.Checked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "PopUpOutOfGame", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState PopUpOutOfGame = CheckState.Checked;

        [DefaultValue(CheckState.Checked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "SpeakInGame", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState SpeakInGame = CheckState.Checked;

        [DefaultValue(CheckState.Unchecked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "SpeakOutOfGame", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState SpeakOutOfGame = CheckState.Unchecked;

        [DefaultValue(true)]
        [JsonProperty(PropertyName = "OperationBriefingsAllowed", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool OperationBriefingsAllowed = true;

        [DefaultValue(false)]
        [JsonProperty(PropertyName = "ResetBriefingsAllowed", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool ResetBriefingsAllowed = false;

        [DefaultValue(true)]
        [JsonProperty(PropertyName = "CyclicBriefingsAllowed", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool CyclicBriefingsAllowed = true;

        [DefaultValue(true)]
        [JsonProperty(PropertyName = "ExtractorBriefingsAllowed", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool ExtractorBriefingsAllowed = true;

        [DefaultValue(true)]
        [JsonProperty(PropertyName = "WarningTimeAllowed", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool WarningTimeAllowed = true;

        [DefaultValue(10)]
        [JsonProperty(PropertyName = "WarningTimeAmount", DefaultValueHandling = DefaultValueHandling.Populate)]
        public decimal WarningTimeAmount = 10;

        [DefaultValue(false)]
        [JsonProperty(PropertyName = "EnableDebugLog", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool EnableDebugLog = false;

        [DefaultValue(defaultRelevantPrefix)]
        [JsonProperty(PropertyName = "RelevantPrefix", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string RelevantPrefix = defaultRelevantPrefix;

        [DefaultValue(defaultRelevantSuffix)]
        [JsonProperty(PropertyName = "RelevantSuffix", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string RelevantSuffix = defaultRelevantSuffix;

        [DefaultValue(CheckState.Checked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "DailyResets", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState DailyResets = CheckState.Checked;

        [DefaultValue(CheckState.Checked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "MissionResets", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState MissionResets = CheckState.Checked;

        [DefaultValue(CheckState.Checked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "CetusDayNotifications", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState CetusDayNotifications = CheckState.Checked;

        [DefaultValue(CheckState.Checked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "CetusNightNotifications", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState CetusNightNotifications = CheckState.Checked;

        [DefaultValue(CheckState.Unchecked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "EarthDayNotifications", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState EarthDayNotifications = CheckState.Unchecked;

        [DefaultValue(CheckState.Unchecked)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "EarthNightNotifications", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState EarthNightNotifications = CheckState.Unchecked;

        [DefaultValue(CheckState.Unchecked)]
        [JsonProperty(PropertyName = "UndefinedInterest", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState UndefinedInterest = CheckState.Unchecked;

        [DefaultValue(defaultTag)]
        [JsonProperty(PropertyName = "UndefinedTediousTag", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string UndefinedTediousTag = defaultTag;

        [DefaultValue(CheckState.Indeterminate)]
        [JsonProperty(PropertyName = "CreditsInterest", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState CreditsInterest = CheckState.Indeterminate;

        [DefaultValue(12500)]
        [JsonProperty(PropertyName = "CreditsAmount", DefaultValueHandling = DefaultValueHandling.Populate)]
        public decimal CreditsAmount = 12500;

        [DefaultValue(defaultTag)]
        [JsonProperty(PropertyName = "CreditsTediousTag", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string CreditsTediousTag = defaultTag;

        [DefaultValue(CheckState.Indeterminate)]
        [JsonProperty(PropertyName = "EndoInterest", DefaultValueHandling = DefaultValueHandling.Populate)]
        public CheckState EndoInterest = CheckState.Indeterminate;

        [DefaultValue(150)]
        [JsonProperty(PropertyName = "EndoAmount", DefaultValueHandling = DefaultValueHandling.Populate)]
        public decimal EndoAmount = 150;

        [DefaultValue(defaultTag)]
        [JsonProperty(PropertyName = "EndoTediousTag", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string EndoTediousTag = defaultTag;

        [DefaultValue(DefaultCustomSearch)]
        [JsonProperty(PropertyName = "CustomSearch", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string CustomSearch = DefaultCustomSearch;

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "EarthCyclicAnchor", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public long EarthCyclicAnchor;

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "CetusCyclicAnchor", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public long CetusCyclicAnchor;

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "TitanExtractorsExpiry", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public long TitanExtractorsExpiry;

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "DistillingExtractorsExpiry", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public long DistillingExtractorsExpiry;
    }
}
