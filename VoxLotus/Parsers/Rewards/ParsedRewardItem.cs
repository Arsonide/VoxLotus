using System.Windows.Forms;

namespace VoxLotus.Parsers
{
    public abstract class ParsedRewardItem
    {
        protected abstract CheckState Interest { get; }
        protected abstract string TediousTag { get; }

        public abstract string Description(bool spoken = false);

        public virtual bool Relevant(string missionType)
        {
            if (Interest == CheckState.Checked)
                return true;

            if (Interest == CheckState.Unchecked)
                return false;

            if (string.IsNullOrEmpty(missionType))
                return true;

            return !ConfigurationManager.Instance.GetTediousMissions(TediousTag).Contains(missionType);
        }
    }
}