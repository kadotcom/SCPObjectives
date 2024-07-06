using Exiled.API.Features;
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

            if (Plugin.Instance.API.PlayersWhoHasReceivedObjectives.Contains(ev.Player) && !Plugin.Instance.Config.GiveObjectivesWhenAPlayerRespawns)
            {
                return;
            }

            if (Plugin.Instance.Config.GiveObjectivesWhenAPlayerRespawns || Plugin.Instance.API.GetAmountObjectives(ev.Player) > 0)
            {
                foreach (PlayerObjective o in Plugin.Instance.API.GetPlayerObjectives(ev.Player))
                {
                    Plugin.Instance.API.Objectives.Remove(o);
                }
            }

            for (int i = 0; i < Plugin.Instance.Config.AmountOfObjectivesGiven; i++)
            {
                Objective o = Plugin.Instance.API.GetRandomObjective(ev.Player);

                if (o != null)
                {
                    Plugin.Instance.API.AssignObjective(o, ev.Player);
                }
                else
                {
                    PluginAPI.Core.Log.Debug("Random objective is null, that either means the objective was meant for a certain role, or you don't have enough objectives.");
                }
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

            foreach (Player p in Player.List)
            {
                if (p.CurrentRoom.Type == Exiled.API.Enums.RoomType.Surface)
                {
                    if (Plugin.Instance.API.PlayerHasObjective(p, API.Enums.ObjectiveEnum.AssistEscape))
                    {
                        PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(p, API.Enums.ObjectiveEnum.AssistEscape);

                        po.Current++;
                        if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                        {
                            Plugin.Instance.API.MarkObjectiveAsComplete(po);
                        }
                    }
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

        public void UseItem(UsedItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.SCP207 || ev.Item.Type == ItemType.AntiSCP207)
            {
                if (Plugin.Instance.API.PlayerHasObjective(ev.Player, API.Enums.ObjectiveEnum.DrinkCola))
                {
                    PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(ev.Player, API.Enums.ObjectiveEnum.DrinkCola);

                    po.Current++;
                    if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                    {
                        Plugin.Instance.API.MarkObjectiveAsComplete(po);
                    }
                }
            }
        }

        public void OpenDoor(Exiled.Events.EventArgs.Player.InteractingDoorEventArgs ev)
        {
            if(ev.Door.Type == Exiled.API.Enums.DoorType.GateA || ev.Door.Type == Exiled.API.Enums.DoorType.GateB)
            {
                if (Plugin.Instance.API.PlayerHasObjective(ev.Player, API.Enums.ObjectiveEnum.AccessGate))
                {
                    PlayerObjective po = Plugin.Instance.API.GetPlayerObjectiveFromEnum(ev.Player, API.Enums.ObjectiveEnum.AccessGate);

                    po.Current++;
                    if (po.Current >= po.objective.NeededToComplete && !po.IsCompleted)
                    {
                        Plugin.Instance.API.MarkObjectiveAsComplete(po);
                    }
                }

            }
        }
    }
}