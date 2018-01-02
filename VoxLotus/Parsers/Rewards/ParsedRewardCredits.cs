using System.Windows.Forms;

namespace VoxLotus.Parsers
{
    public class ParsedRewardCredits : ParsedRewardCurrency
    {
        public ParsedRewardCredits(decimal amount) : base(amount) { }
        protected override string Name => "Credit";
        protected override string Prefix => "a";
        protected override decimal Minimum => ConfigurationManager.Instance.Settings.CreditsAmount;
        protected override CheckState Interest => ConfigurationManager.Instance.Settings.CreditsInterest;
        protected override string TediousTag => ConfigurationManager.Instance.Settings.CreditsTediousTag;
    }
}