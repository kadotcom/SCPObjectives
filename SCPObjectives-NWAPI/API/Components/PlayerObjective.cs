using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCPObjectives_NWAPI.API.Components
{
    public class PlayerObjective
    {
        public Player player;

        public Objective objective;

        public int Current = 0;

        public bool IsCompleted = false;
    }
}
