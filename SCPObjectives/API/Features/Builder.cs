using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using SCPObjectives.API.Components;
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
                    s += $"\n{o.objective.ObjectiveString} - COMPLTETED";
                }
                else
                {
                    s += $"\n{o.objective.ObjectiveString} - {o.Current}/{o.objective.NeededToComplete}";
                }
            }

            return s;
        }

        public static string BuildCompletedString(PlayerObjective p)
        {
            string hint = $"Completed {p.objective.ObjectiveString}";

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

            return BuildHint(hint, "36fe04ff");
        }
    }
}
