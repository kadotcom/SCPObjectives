using Exiled.API.Features;
using SCPObjectives.API.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCPObjectives.API.Features
{
    public class Builder
    {
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
