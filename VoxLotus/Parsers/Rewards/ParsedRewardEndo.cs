using System.Windows.Forms;

namespace VoxLotus.Parsers
{
    public class ParsedRewardEndo : ParsedRewardCurrency
    {
        public ParsedRewardEndo(decimal amount) : base(amount) { }
        protected override string Name => "Endo";
        protected override string Prefix => "an";
        protected override decimal Minimum => ConfigurationManager.Instance.Settings.EndoAmount;
        protected override CheckState Interest => ConfigurationManager.Instance.Settings.EndoInterest;
        protected override string TediousTag => ConfigurationManager.Instance.Settings.EndoTediousTag;

        public static bool IsEndo(string name, out decimal amount)
        {
            string[] words = name.Split(' ');

            if (words.Length <= 0 || words[words.Length - 1].ToLowerInvariant() != "endo")
            {
                amount = 0;
                return false;
            }

            if (!decimal.TryParse(words[0], out amount))
                amount = 0;

            return true;
        }
    }
}