using Exiled.API.Interfaces;
using SCPObjectives.API.Components;
using System.Collections.Generic;
using System.ComponentModel;

namespace SCPObjectives
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        [Description("If enabled, the plugin will assign objectives, do not disable unless you have a seperate plugin that will assign the objectives.")]
        public bool AssignObjective { get; set; } = true;

        [Description("How many objectives will be given when a player initially spawns, or, if GiveObjectivesWhenAPlayerRespawns is enabled, when a player respawns.")]
        public int AmountOfObjectivesGiven { get; set; } = 2;

        [Description("If enabled, when a player dies, the objectives that the player had will be cleared.")]
        public bool ClearAllObjectivesOnPlayersDeath { get; set; } = false;

        [Description("If enabled, when a player spawns in after dying, new objectives will be given.")]
        public bool GiveObjectivesWhenAPlayerRespawns { get; set; } = false;

        [Description("List of objectives the player can get.")]
        public List<Objective> Objectives { get; set; } = new List<Objective>() { 
            new Objective()
            {
                ObjectiveString = "Escape The Facility",
                ObjectiveType = API.Enums.ObjectiveEnum.EscapeFacility,
                Rewards = new List<API.Enums.RewardEnum>()
                {
                    API.Enums.RewardEnum.Item
                },
                IsRoleSpecific = true,
                RolesThatCanGetObjective = new List<PlayerRoles.RoleTypeId>()
                {
                    PlayerRoles.RoleTypeId.ClassD,
                    PlayerRoles.RoleTypeId.Scientist
                },
                NeededToComplete = 1,
                RewardItem = ItemType.KeycardScientist,
            },
            new Objective()
            {
                ObjectiveString = "Handcuff Someone",
                ObjectiveType = API.Enums.ObjectiveEnum.Handcuff,
                Rewards = new List<API.Enums.RewardEnum>()
                {
                    API.Enums.RewardEnum.CustomItem
                },
                NeededToComplete = 1,
                RewardCustomItem = 1,
            },
        };
    }
}