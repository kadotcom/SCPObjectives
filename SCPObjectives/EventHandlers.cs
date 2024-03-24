using Exiled.Events.EventArgs.Player;
using SCPObjectives.API.Components;
using SCPObjectives.API.Features;

namespace SCPObjectives
{
    public class EventHandlers
    {
        public void Restart()
        {
            Plugin.Instance.API.Clear();
        }

        public void Spawned(SpawnedEventArgs ev)
        {
            if(Plugin.Instance.API.PlayersWhoHasReceivedObjectives.Contains(ev.Player) && !Plugin.Instance.Config.GiveObjectivesWhenAPlayerRespawns)
            {
                return;
            }

            for(int i = 0; i < Plugin.Instance.Config.AmountOfObjectivesGiven;  i++)
            {
                Objective o = Plugin.Instance.API.GetRandomObjective();

                int reattempts = 0;
                while(o.IsRoleSpecific && !o.RolesThatCanGetObjective.Contains(ev.Player.Role.Type))
                {
                    PluginAPI.Core.Log.Debug(reattempts.ToString());
                    if (reattempts > 15) break;
                    o = Plugin.Instance.API.GetRandomObjective();
                    reattempts++;
                }
                Plugin.Instance.API.AssignObjective(o, ev.Player);
                PluginAPI.Core.Log.Debug((i + 1).ToString() + " - Objective");
            }

            if (!Plugin.Instance.Config.GiveObjectivesWhenAPlayerRespawns)
            {
                Plugin.Instance.API.PlayersWhoHasReceivedObjectives.Add(ev.Player);
            }

            ev.Player.SendConsoleMessage(Builder.BuildObjectiveString(ev.Player), "white");
        }

        public void Kill(DyingEventArgs ev)
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

        public void Escape(EscapingEventArgs ev)
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

        public void Hurt(HurtEventArgs ev)
        {
            if (ev.Attacker == null) return;

            if (Plugin.Instance.API.PlayerHasObjective(ev.Attacker, API.Enums.ObjectiveEnum.DealDamage))
            {
                PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(ev.Attacker, API.Enums.ObjectiveEnum.DealDamage);

                PluginAPI.Core.Log.Debug(po.Current + "/" + po.objective.NeededToComplete + " - before");
                po.Current += (int)ev.Amount;
                PluginAPI.Core.Log.Debug(po.Current + "/" + po.objective.NeededToComplete + " - after");

                if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                {
                    Plugin.Instance.API.MarkObjectiveAsComplete(po);
                }
            }
        }
    }
}