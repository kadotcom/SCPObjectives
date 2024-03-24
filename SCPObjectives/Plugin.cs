using Exiled.API.Features;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;

namespace SCPObjectives
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "KadotCom";

        public override string Name => "SCPObjectives";

        public override string Prefix => Name;

        public static Plugin Instance;

        private EventHandlers _handlers;

        public API.API API;

        public override void OnEnabled()
        {
            Instance = this;

            API = new API.API();

            if(XPSystem.Main.Instance == null && Config.Debug)
            {
                PluginAPI.Core.Log.Warning("[SCPObjectives] XPSystem couldn't be found, anything that awards XP for completing objectives won't work.");
            }

            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            API = null;

            Instance = null;

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _handlers = new EventHandlers();

            PlayerEvents.Spawned += _handlers.Spawned;
            PlayerEvents.Escaping += _handlers.Escape;
            PlayerEvents.Dying += _handlers.Kill;
            PlayerEvents.Hurt += _handlers.Hurt;

            ServerEvents.RestartingRound += _handlers.Restart;
        }

        private void UnregisterEvents()
        {
            PlayerEvents.Spawned -= _handlers.Spawned;
            PlayerEvents.Escaping -= _handlers.Escape;
            PlayerEvents.Dying -= _handlers.Kill;
            PlayerEvents.Hurt -= _handlers.Hurt;

            ServerEvents.RestartingRound -= _handlers.Restart;

            _handlers = null;
        }
    }
}