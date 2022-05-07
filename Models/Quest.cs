using System;
using System.Collections.Generic;
using Portals_Technoprolis_RPG.Models;
using Portals_Technoprolis_RPG.Activities;

namespace Portals_Technoprolis_RPG.Models
{
    [Serializable]
    //properties to generate Quests
    public class Quest
    {
        public int QuestID { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public int AwardXP { get; set; }
        public int AwardLoot { get; set; }
        public bool QuestComplete { get; set; }

        public List<Achievement> AchievementCollection { get; set; }

        public Quest(int questID, string questName, string questDescription, int awardXp, int awardLoot)
        {
            QuestID = questID;
            QuestName = questName;
            QuestDescription = questDescription;
            AwardXP = awardXp;
            AwardLoot = awardLoot;
            QuestComplete = false;

            AchievementCollection = new List<Achievement>();
        }

    }
    public class Achievement : Quest
    {
        //get the details from the Artifact class:
        public Artifact Details { get; set; }
        public int Quantity { get; set; }

        public Achievement(Artifact details, int quantity, int questID, string questName, string questDescript,
                int awardXp, int awardLoot) : base(questID, questName, questDescript, awardXp, awardLoot)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
