using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPObjectives_NWAPI
{
    public class Plugin
    {
        public static Plugin Instance;

        [PluginConfig] public Config Config;

        public const string Version = "1.0.0";

        public EventHandler _handler;

        public API.API API;

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("SCPObjectives-NWAPI", Version, "An SCP:SL plugin that adds objectives.","KadotCom")]
        void LoadPlugin()
        {
            _handler = new EventHandler();
            Instance = this;
            API = new API.API();
            PluginAPI.Events.EventManager.RegisterEvents(_handler);

            if (XPSystem.Main.Instance == null && Config.Debug)
            {
                PluginAPI.Core.Log.Warning("XPSystem couldn't be found, anything that awards XP for completing objectives won't work.");
            }
            if (NWAPI.CustomItems.Plugin.Instance == null && Config.Debug)
            {
                PluginAPI.Core.Log.Warning("NWAPI-CustomItems couldn't be found, anything that awards CustomItems for completing objectives won't work.");
            }
        }

    }
}
