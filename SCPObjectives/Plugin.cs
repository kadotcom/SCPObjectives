using Exiled.API.Features;
using System;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;

namespace SCPObjectives
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "KadotCom";

        public override string Name => "SCPObjectives";

        public override string Prefix => Name;

        public override Version Version => new Version(1,0,0);

        public static Plugin Instance;

        private EventHandlers _handlers;

        public API.API API;

        public override void OnEnabled()
        {
            Instance = this;

            API = new API.API();

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
            PlayerEvents.Handcuffing += _handlers.Handcuff;
            PlayerEvents.EscapingPocketDimension += _handlers.EscapePocketDimension;
            PlayerEvents.ActivatingGenerator += _handlers.EnableGenerator;
            PlayerEvents.PickingUpItem += _handlers.PickUpItem;

            ServerEvents.RestartingRound += _handlers.Restart;
        }

        private void UnregisterEvents()
        {
            PlayerEvents.Spawned -= _handlers.Spawned;
            PlayerEvents.Escaping -= _handlers.Escape;
            PlayerEvents.Dying -= _handlers.Kill;
            PlayerEvents.Hurt -= _handlers.Hurt;
            PlayerEvents.Handcuffing -= _handlers.Handcuff;
            PlayerEvents.EscapingPocketDimension -= _handlers.EscapePocketDimension;
            PlayerEvents.ActivatingGenerator -= _handlers.EnableGenerator;
            PlayerEvents.PickingUpItem -= _handlers.PickUpItem;

            ServerEvents.RestartingRound -= _handlers.Restart;

            _handlers = null;
        }
    }
}