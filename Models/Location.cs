using System;
using System.Collections.Generic;
using Portals_Technoprolis_RPG.Models;
using Portals_Technoprolis_RPG.Activities;

namespace Portals_Technoprolis_RPG.Models
{
    [Serializable]
    public class Location
    {
        //properties
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }

        //object type properties for NPC/Items/Quests available to Player
        public Quest QuestAvailable { get; set; }
        public Artifact ArtifactRequired { get; set; }
        public Npc NpcInteraction { get; set; }

        //object type properties for player moves:
        public Location MoveNorth { get; set; }
        public Location MoveEast { get; set; }
        public Location MoveWest { get; set; }
        public Location MoveSouth { get; set; }


        public Location(int locID, string locName, string locDescript)
        {
            LocationID = locID;
            LocationName = locName;
            LocationDescription = locDescript;
        }

        public string DisplayLocation()
        {

            return "Current location: " + LocationName + " " + LocationDescription + " \n";
        }

        public void MovePlayer()
        {
            throw new NotImplementedException();
        }
    }
}
