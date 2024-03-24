using System;
using System.Collections.Generic;
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

        public List<Objective> Objectives { get; set; } = new List<Objective>()
        {
            new Objective()
        };
    }
}
