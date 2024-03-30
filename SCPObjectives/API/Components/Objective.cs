using PlayerRoles;
using SCPObjectives.API.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace SCPObjectives.API.Components
{
    public class Objective
    {
        [Description("The objective that you need to complete (read the GitHub README for each ObjectiveType)")]
        public ObjectiveEnum ObjectiveType { get; set; } = ObjectiveEnum.None;

        [Description("Determines if a certain role can get/complete the objective.")]
        public bool IsRoleSpecific { get; set; } = false;

        [Description("List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.")]
        public List<RoleTypeId> RolesThatCanGetObjective { get; set; } = new List<RoleTypeId>();

        [Description("The reward you'll get once the objective is completed (read the GitHub README for each RewardType)")]
        public RewardEnum Reward { get; set; } = RewardEnum.None;

        [Description("The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')")]
        public string ObjectiveString { get; set; } = "Do Absolutely Nothing";

        [Description("The amount that is needed to complete an objective.")]
        public int NeededToComplete { get; set; } = 0;

        [Description("The ItemType you'll get if you complete an objective (if reward is set to Item)")]
        public ItemType RewardItem { get; set; } = ItemType.None;

        [Description("The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)")]
        public uint RewardCustomItem { get; set; } = 0;

        [Description("The amount of XP you'll get if you complete an objective. (if reward is set to XP)")]
        public int RewardXP { get; set; } = 0;
    }
}
