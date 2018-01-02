namespace VoxLotus
{
    public enum ConfigEntryType
    {
        Unknown,
        Planet,
        Resource,
        Aura,
        Mod,
        Blueprint,
        Helmet,
        Weapon,
        Skin,
        Other
    }

    public enum DescriptionType
    {
        Written,
        Spoken,
        Logged,
        Progress
    }

    public enum TickerState
    {
        Uninitialized,
        Enabled,
        Disabled,
        Enabling,
        Disabling
    }

    public enum ConnectionStatus
    {
        Connecting,
        Connected,
        Issue
    }
}
