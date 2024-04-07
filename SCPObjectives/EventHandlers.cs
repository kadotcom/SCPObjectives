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
            if (Plugin.Instance.Config.Objectives.Count == 0)
            {
                if (Plugin.Instance.Config.Debug)
                {
                    PluginAPI.Core.Log.Debug("You don't have any Objectives defined in the config.");
                }
                return;
            }

            if(Plugin.Instance.API.PlayersWhoHasReceivedObjectives.Contains(ev.Player) && !Plugin.Instance.Config.GiveObjectivesWhenAPlayerRespawns)
            {
                return;
            }

            if (Plugin.Instance.Config.GiveObjectivesWhenAPlayerRespawns || Plugin.Instance.API.GetAmountObjectives(ev.Player) > 0)           
            {
                foreach(PlayerObjective o in Plugin.Instance.API.GetPlayerObjectives(ev.Player))
                {
                    Plugin.Instance.API.Objectives.Remove(o);
                }
            }

            for(int i = 0; i < Plugin.Instance.Config.AmountOfObjectivesGiven;  i++)
            {
                Objective o = Plugin.Instance.API.GetRandomObjective(ev.Player);

                Plugin.Instance.API.AssignObjective(o, ev.Player);
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

                po.Current++;
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

                po.Current += (int)ev.Amount;

                if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                {
                    Plugin.Instance.API.MarkObjectiveAsComplete(po);
                }
            }
        }

        public void Handcuff(HandcuffingEventArgs ev) {
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

        public void EnableGenerator(ActivatingGeneratorEventArgs ev)
        {
            if (Plugin.Instance.API.PlayerHasObjective(ev.Player, API.Enums.ObjectiveEnum.EnableGenerators))
            {
                PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(ev.Player, API.Enums.ObjectiveEnum.EnableGenerators);

                po.Current++;
                if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                {
                    Plugin.Instance.API.MarkObjectiveAsComplete(po);
                }
            }
        }

        public void EscapePocketDimension(EscapingPocketDimensionEventArgs ev)
        {
            if (Plugin.Instance.API.PlayerHasObjective(ev.Player, API.Enums.ObjectiveEnum.EscapePocketDimension))
            {
                PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(ev.Player, API.Enums.ObjectiveEnum.EscapePocketDimension);

                po.Current++;
                if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                {
                    Plugin.Instance.API.MarkObjectiveAsComplete(po);
                }
            }
        }

        public void PickUpItem(PickingUpItemEventArgs ev)
        {
            if (Plugin.Instance.API.PlayerHasObjective(ev.Player, API.Enums.ObjectiveEnum.PickUpItem))
            {
                PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(ev.Player, API.Enums.ObjectiveEnum.PickUpItem);

                po.Current++;
                if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                {
                    Plugin.Instance.API.MarkObjectiveAsComplete(po);
                }
            }
        }
    }
}