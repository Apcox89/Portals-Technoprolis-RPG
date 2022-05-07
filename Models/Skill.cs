using System;
using System.Collections.Generic;
using Portals_Technoprolis_RPG.Models;
using Portals_Technoprolis_RPG.Activities;

namespace Portals_Technoprolis_RPG.Models
{
    [Serializable]
    //class to act as a menu for player skill upgrades
    //the Player can dynamically assign upon quest completion
    //using the PlayerSkill "strategy" design method
    public class Skill : IEquatable<Skill>
    {
        //a simple class to instantiate a list of skills assigned to a Player
        public int SkillID { get; set; }
        public string SkillName { get; set; }

        public Skill(int skillID, string skillName)
        {
            SkillID = skillID;
            SkillName = skillName;
        }

        public override string ToString()
        {
            return "ID: " + SkillID + "   Name: " + SkillName;
        }

        public override int GetHashCode()
        {
            return SkillID;
        }
        public bool Equals(Skill other)
        {
            if (other == null) return false;
            return (this.SkillID.Equals(other.SkillID));
        }
    }
}
