using System;
using System.Collections.Generic;
using System.Linq;
using VoxLotus.Parsers;
using WarframeNET;

namespace VoxLotus
{
    public class ParsedReward
    {
        protected readonly List<ParsedRewardItem> allItems = new List<ParsedRewardItem>();
        protected readonly List<ParsedRewardItem> relevantItems = new List<ParsedRewardItem>();

        protected string missionType = "";

        public ParsedReward(string missionType, Reward reward)
        {
            SetRewards(missionType, reward);
        }

        public ParsedReward(Alert alert)
        {
            SetRewards(alert.Mission.Type, alert.Mission.Reward);
        }

        public ParsedReward(Invasion invasion)
        {
            SetRewards("Invasion", invasion.AttackerReward, invasion.DefenderReward);
        }

        public void SetRewards(string missionType, params Reward[] rewards)
        {
            this.missionType = missionType;
            allItems.Clear();

            decimal maxEndo = 0;
            decimal maxCredits = 0;

            foreach (Reward reward in rewards)
            {
                decimal rewardEndo = 0;

                foreach (string item in reward.Items)
                {

                    if (ParsedRewardEndo.IsEndo(item, out decimal itemEndo))
                        rewardEndo += itemEndo;
                    else
                        allItems.Add(new ParsedRewardSingular(item));
                }

                foreach (CountedItem item in reward.CountedItems)
                {
                    allItems.Add(new ParsedRewardCounted(item));
                }

                maxEndo = Math.Max(rewardEndo, maxEndo);
                maxCredits = Math.Max(reward.Credits, maxCredits);
            }

            if (maxEndo > 0)
                allItems.Add(new ParsedRewardEndo(maxEndo));

            if (maxCredits > 0)
                allItems.Add(new ParsedRewardCredits(maxCredits));

            CheckRelevance(missionType);
        }

        public void CheckRelevance(string missionType)
        {
            relevantItems.Clear();

            foreach (ParsedRewardItem item in allItems)
            {
                if (item.Relevant(missionType))
                    relevantItems.Add(item);
            }
        }

        public bool Relevant => relevantItems.Count > 0;

        public string Description(bool relevant, bool tagged, bool spoken)
        {
            List<ParsedRewardItem> items = relevant ? relevantItems : allItems;

            List<string> descriptions = new List<string>();

            foreach (ParsedRewardItem item in items)
            {
                string prefix = string.Empty;
                string suffix = string.Empty;

                if (tagged && item.Relevant(missionType))
                {
                    prefix = ConfigurationManager.Instance.Settings.RelevantPrefix;
                    suffix = ConfigurationManager.Instance.Settings.RelevantSuffix;
                }

                descriptions.Add($"{prefix}{item.Description(spoken)}{suffix}");
            }

            return string.Join(", ", descriptions.Take(items.Count - 1)) + (descriptions.Count <= 1 ? "" : " and ") + descriptions.LastOrDefault();
        }
    }
}