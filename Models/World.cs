using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals_Technoprolis_RPG.Models
{

    //to hold the values set for game object interaction
    //really should be data communicated through an API/DB
    //SSMS + custom Json <RestSharp> style API
    //Cox note: add to db
    public static class World
    {
        public static readonly List<Location> Locations = new List<Location>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Artifact> Artifacts = new List<Artifact>();
        public static readonly List<Npc> Npcs = new List<Npc>();

        //locations
        public const int LOCATION_ID_BASE_CAMP = 1;
        public const int LOCATION_ID_DESTROYED_STATUE = 2;
        public const int LOCATION_ID_ABANDONED_SATELLITE = 3;
        public const int LOCATION_ID_TERMINAL_ACCESS = 4;
        public const int LOCATION_ID__FOREST = 5;
        public const int LOCATION_ID_REBEL_OUTPOST = 6;
        public const int LOCATION_ID_ROBO_GUARD_CAMP = 7;
        public const int LOCATION_ID_OBSERVER_BATTLE = 8;
        public const int LOCATION_ID_BRIDGE = 9;
        public const int LOCATION_ID_ROBO_GUARD_MAIN_BASE = 10;

        //missions
        public const int MISSION_ID_CLEAR_TERMINAL_ACCESS = 1;
        public const int MISSION_ID_CLEAR_ROBO_GUARD_CAMP = 2;
        public const int MISSION_ID_CLEAR_OBSERVER_BATTLE = 3;
        public const int MISSION_ID_CLEAR_ROBO_GUARD_MAIN_BASE = 4;

        //weapons
        public const int ARTIFACT_ID_AXE_HANDLE = 1;
        public const int ARTIFACT_ID_PROGRAMETER = 2;
        public const int ARTIFACT_ID_PHASER_PISTOL = 3;
        public const int ARTIFACT_ID_PHASER_AMMO = 4;

        //quest-items to be obtained and collected to pass onto next area
        public const int ARTIFACT_ID_COMMS_MESSAGE = 5;
        public const int ARTIFACT_ID_COMMS_DIAGRAM = 6;
        public const int ARTIFACT_ID_ROBO_HEART = 7;
        public const int ARTIFACT_ID_OCULUS = 8;
        public const int ARTIFACT_ID_ROBO_BRAIN = 9;

        //elixer(s)'s
        public const int ARTIFACT_ID_REVIVE = 10;

        //OBTAIN THE CORRECT AMOUNT OF ARTIFACTS FROM NPC'S TO BUILD THIS UNIT AND PASS LEVEL
        //BASICALLY THIS UNIT ALLOWS ACCESS TO THE FIRST PORTAL OF TECHNOPROLIS
        public const int ARTIFACT_ID_PROGRAMETER_SIGHT_UPGRADE = 11;
        public const int ARTIFACT_ID_BUILD_PARSY = 12;

        //npcs
        //villains
        public const int NPC_ID_ROBO_COMMS_CLIENT = 1;
        public const int NPC_ID_ROBO_COMMANDO = 2;
        public const int NPC_ID_OBSERVER = 3;
        public const int NPC_ID_ROBO_LEADER = 4;

        //Bill's Ai sidekick can be built upon completion of missions in this level, to gain access to the first portal.
        public const int NPC_ID_FRIEND_PARSY = 5;

        static World()
        {
            GenerateLocations();
            GenerateArtifacts();
            GenerateNpcs();
            GenerateQuests();
        }

        private static void GenerateLocations()
        {
            //each instance of a location now added to the object type list
            Location baseCamp = new Location(LOCATION_ID_BASE_CAMP, "Base-Camp",
                    "Bill Gnan'ts hovel somewhere in the outskirts of Technoprolis.");
            Location destroyedStatue = new Location(LOCATION_ID_DESTROYED_STATUE, "Destroyed Statue",
                    " A statue of one of the last leaders of the human-freedom movement has fallen.");
            Location abandonedSatellite = new Location(LOCATION_ID_ABANDONED_SATELLITE, "Abandoned Satellite",
                    "Once used for inter-human telecommunication, the robots deemed this facility unusable for their purposes.");
            Location terminalAccess = new Location(LOCATION_ID_TERMINAL_ACCESS, "Terminal-Computer Access",
                    "There is an old computer terminal that works here."); terminalAccess.QuestAvailable = FindQuestByID(MISSION_ID_CLEAR_TERMINAL_ACCESS);

            Locations.Add(baseCamp);
            Locations.Add(abandonedSatellite);
            Locations.Add(destroyedStatue);
            Locations.Add(terminalAccess);
        }

        private static void GenerateArtifacts()
        {

            Artifacts.Add(new Weapon(1, 3, ARTIFACT_ID_AXE_HANDLE, " Blunt-Axe-Handle"));
            Artifacts.Add(new Weapon(1, 3, ARTIFACT_ID_PROGRAMETER, " Progra-meter"));

        }

        private static void GenerateNpcs()
        {

            Npc roboMessageClient = new Npc(NPC_ID_ROBO_COMMS_CLIENT, " Robo Message Client", 3, 20, 10, 7, 7);

            Npcs.Add(roboMessageClient);

        }

        private static void GenerateQuests()
        {
            Quest clearTerminalAccess = new Quest();
            clearTerminalAccess.ID = MISSION_ID_CLEAR_TERMINAL_ACCESS;
            clearTerminalAccess.Name = "Terminal Access";
            clearTerminalAccess.Description = "Hack the terminal to gain a comms access port to Technoprolis. " +
                                              "Decrypt 5 messages using your Programeter device to earn the communications skill upgrade, and earn 250xp.";
            clearTerminalAccess.AwardXP = 250;
            clearTerminalAccess.AwardLoot = 25;
        }


        public static Quest FindQuestByID(int id)
        {
            return Quests.FirstOrDefault(q => q.ID == id);
        }


        public static Artifact FindArtifactByID(int id)
        {
            foreach (Artifact _artifact in Artifacts)
            {
                if (_artifact.ID == id)
                {
                    return _artifact;
                }
            }
            return null;
        }

        public static Npc FindNpcByID(int id)
        {
            foreach (Npc _npc in Npcs)
            {
                if (_npc.ID == id)
                {
                    return _npc;
                }
            }
            return null;
        }

        public static Location FindLocationByID(int id)
        {
            foreach (Location _location in Locations)
            {
                if (_location.ID == id)
                {
                    return _location;
                }
            }
            return null;
        }
    }
}
