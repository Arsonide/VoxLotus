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

        public string Description(bool relevant, bool spoken = false)
        {
            List<string> items = relevant ? relevantItems.Select(i => i.Description(spoken)).ToList() : allItems.Select(i => i.Description(spoken)).ToList();
            return string.Join(", ", items.Take(items.Count - 1)) + (items.Count <= 1 ? "" : " and ") + items.LastOrDefault();
        }
    }
}