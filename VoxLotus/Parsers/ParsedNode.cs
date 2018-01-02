using WarframeNET;

namespace VoxLotus.Parsers
{
    public class ParsedNode
    {
        public readonly string Sector;
        public readonly string Planet;

        protected ConfigurationEntry sectorEntry;
        protected ConfigurationEntry planetEntry;

        public ParsedNode(string node)
        {
            LoadFromNode(node, out Sector, out Planet);
        }

        public ParsedNode(Alert alert)
        {
            LoadFromNode(alert.Mission.Node, out Sector, out Planet);
        }

        public ParsedNode(Invasion invasion)
        {
            LoadFromNode(invasion.Node, out Sector, out Planet);
        }

        protected void LoadFromNode(string node, out string sector, out string planet)
        {
            string[] splits = node.Split('(', ')');
            sector = splits.Length > 0 ? splits[0].Trim() : string.Empty;
            planet = splits.Length > 1 ? splits[1].Trim() : string.Empty;
            sectorEntry = ConfigurationManager.Instance.GetEntryByName(Sector);
            planetEntry = ConfigurationManager.Instance.GetEntryByName(Planet);
        }

        public string SectorDescription(bool prefix, bool spoken = false)
        {
            if (sectorEntry == null)
                return Sector;

            string sector = spoken ? sectorEntry.GetPronunciation() : sectorEntry.GetDisplay();
            return prefix ? $"{sectorEntry.EntryPrefix} {sector}" : sector;
        }

        public string PlanetDescription(bool prefix, bool spoken = false)
        {
            if (planetEntry == null)
                return Planet;

            string planet = spoken ? planetEntry.GetPronunciation() : planetEntry.GetDisplay();
            return prefix ? $"{planetEntry.EntryPrefix} {planet}" : planet;
        }
    }
}