using Exiled.API.Features;
using SCPObjectives.API.Components;

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
    }
}
