using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI;
using PluginAPI.Core;
using SCPObjectives_NWAPI.API.Components;

namespace SCPObjectives_NWAPI
{
    public class Config
    {
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
        public List<Objective> Objectives { get; set; } = new List<Objective>()
        {
            new Objective()
        };
    }
}
