using PluginAPI.Events;
using SCPObjectives_NWAPI.API.Components;
using SCPObjectives_NWAPI.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPObjectives_NWAPI
{
    public class EventHandler
    {
        [PluginAPI.Core.Attributes.PluginEvent]
        public void Restart(RoundRestartEvent ev)
        {
            Plugin.Instance.API.Clear();
        }

        [PluginAPI.Core.Attributes.PluginEvent]
        public void Spawned(PluginAPI.Events.PlayerChangeRoleEvent ev)
        {
            if (ev.ChangeReason != PlayerRoles.RoleChangeReason.RoundStart) return;
            if (Plugin.Instance.API.PlayersWhoHasReceivedObjectives.Contains(ev.Player) && !Plugin.Instance.Config.GiveObjectivesWhenAPlayerRespawns)
            {
                return;
            }

            for (int i = 0; i < Plugin.Instance.Config.AmountOfObjectivesGiven; i++)
            {
                Objective o = Plugin.Instance.API.GetRandomObjective();

                Plugin.Instance.API.AssignObjective(o, ev.Player);
                PluginAPI.Core.Log.Debug((i + 1).ToString() + " - Objective");
            }

            if (!Plugin.Instance.Config.GiveObjectivesWhenAPlayerRespawns)
            {
                Plugin.Instance.API.PlayersWhoHasReceivedObjectives.Add(ev.Player);
            }

            ev.Player.SendConsoleMessage(Builder.BuildObjectiveString(ev.Player), "white");
        }

        [PluginAPI.Core.Attributes.PluginEvent]
        public void Kill(PluginAPI.Events.PlayerDyingEvent ev)
        {
            if (ev.Attacker == null) return;
            if (Plugin.Instance.API.PlayerHasObjective(ev.Attacker, API.Enums.ObjectiveEnum.KillAnotherPerson))
            {
                PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(ev.Attacker, API.Enums.ObjectiveEnum.KillAnotherPerson);

                PluginAPI.Core.Log.Debug(po.Current + "/" + po.objective.NeededToComplete + " - before");
                po.Current++;
                PluginAPI.Core.Log.Debug(po.Current + "/" + po.objective.NeededToComplete + " - after");
                if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                {
                    Plugin.Instance.API.MarkObjectiveAsComplete(po);
                }
            }
        }

        [PluginAPI.Core.Attributes.PluginEvent]
        public void Escape(PluginAPI.Events.PlayerEscapeEvent ev)
        {
            if (Plugin.Instance.API.PlayerHasObjective(ev.Player, API.Enums.ObjectiveEnum.EscapeFacility))
            {
                PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(ev.Player, API.Enums.ObjectiveEnum.EscapeFacility);

                po.Current++;
                if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                {
                    Plugin.Instance.API.MarkObjectiveAsComplete(po);
                }
            }
        }

        [PluginAPI.Core.Attributes.PluginEvent]
        public void Handcuff(PluginAPI.Events.PlayerHandcuffEvent ev)
        {
            if (Plugin.Instance.API.PlayerHasObjective(ev.Player, API.Enums.ObjectiveEnum.Handcuff))
            {
                PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(ev.Player, API.Enums.ObjectiveEnum.Handcuff);

                po.Current++;
                if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                {
                    Plugin.Instance.API.MarkObjectiveAsComplete(po);
                }
            }
        }
    }
}
