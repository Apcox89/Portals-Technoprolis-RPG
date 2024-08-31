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
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AwardXP { get; set; }
        public int AwardLoot { get; set; }
        public bool Completed { get; set; }

        public List<Achievement> AchievementCollection { get; set; }

    }
    public class Achievement
    {
        //get the details from the Artifact class:
        public int ID { get; set; } // Unique identifier for Achievement
        public int QuestID { get; set; } // Foreign key to Quest
        public string Name { get; set; } // Achievement-specific name
        public string Description { get; set; } // Achievement-specific description
        public int Quantity { get; set; }

        // Navigation property for the associated Quest
        public Quest Quest { get; set; }
    }
}
