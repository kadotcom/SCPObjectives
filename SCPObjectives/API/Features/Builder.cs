using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.CustomModules.API.Features.CustomItems;
using SCPObjectives.API.Components;
using SCPObjectives.API.Enums;
using UnityEngine.Assertions.Must;

namespace SCPObjectives.API.Features
{
    public class Builder
    {
        /// <summary>
        /// Builds a centered hint.
        /// </summary>
        /// <param name="hint">hint string</param>
        /// <param name="hex">hex code</param>
        /// <param name="bolded">bolded</param>
        /// <returns>hint string</returns>
        public static string BuildHint(string hint, string hex = "ffffffff", bool bolded = false)
        {
            if (bolded)
            {
                return $"<align=center><b><color=#{hex}>{hint}</color></b></align>";
            }
            else
            {
                return $"<align=center><color=#{hex}>{hint}</color></align>";
            }
        }

        /// <summary>
        /// Builds a message which contains objectives that the player has.
        /// </summary>
        /// <param name="p">player</param>
        /// <returns>objective message</returns>
        public static string BuildObjectiveString(Player p)
        {
            string s = $"Objectives ({Plugin.Instance.API.GetAmountObjectives(p)}):";

            foreach(PlayerObjective o in Plugin.Instance.API.GetPlayerObjectives(p))
            {
                if(o.IsCompleted)
                {
                    s += $"\n{o.objective.ObjectiveString} - {Plugin.Instance.Translation.ObjectiveCompletedCheck}";
                }
                else
                {
                    s += $"\n{o.objective.ObjectiveString} - {o.Current}/{o.objective.NeededToComplete}";
                    foreach(RewardEnum re in o.objective.Rewards)
                    {
                        if(re == RewardEnum.Item)
                        {
                            s += $"\n - " + o.objective.RewardItem;
                        }
                        if (re == RewardEnum.CustomItem)
                        {
                            s += $"\n - " + CustomItem.Get(o.objective.RewardCustomItem).Name;
                        }
                        if (re == RewardEnum.XP)
                        {
                            s += $"\n - " + o.objective.RewardXP + " EXP";
                        }
                        if (re == RewardEnum.Tickets)
                        {
                            if (o.player.Role.Side == Exiled.API.Enums.Side.Mtf)
                            {
                                s += $"\n - " + o.objective.RewardTickets + " MTF Tickets";
                            }
                            else if(o.player.Role.Side == Exiled.API.Enums.Side.ChaosInsurgency)
                            {
                                s += $"\n - " + o.objective.RewardTickets + " CI Tickets";
                            }
                        }

                    }
                }
            }

            return s;
        }

        public static string BuildCompletedString(PlayerObjective p)
        {
            string hint = $"{Plugin.Instance.Translation.ObjectiveCompletedHint} {p.objective.ObjectiveString}";

            if (p.objective.Rewards.Contains(Enums.RewardEnum.Item))
            {
                hint += $"\n+ {p.objective.RewardItem}";
            }
            if (p.objective.Rewards.Contains(Enums.RewardEnum.XP))
            {
                hint += $"\n+ {p.objective.RewardXP} EXP";
            }
            if (p.objective.Rewards.Contains(Enums.RewardEnum.CustomItem))
            {
                hint += $"\n+ {CustomItem.Get(p.objective.RewardCustomItem).Name}";
            }
            if (p.objective.Rewards.Contains(Enums.RewardEnum.Tickets))
            {
                if(p.player.Role.Side == Exiled.API.Enums.Side.ChaosInsurgency)
                {
                    hint += $"\n+ {p.objective.RewardTickets} CI Tickets";
                }
                else if(p.player.Role.Side == Exiled.API.Enums.Side.Mtf)
                {
                    hint += $"\n+ {p.objective.RewardTickets} MTF Tickets";
                }
            }

            return BuildHint(hint, "36fe04ff");
        }
    }
}
