using PlayerRoles;
using SCPObjectives.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCPObjectives.API.Components
{
    public class Objective
    {
        public ObjectiveEnum ObjectiveType { get; set; } = ObjectiveEnum.None;
        
        public bool IsRoleSpecific { get; set; } = false;

        public List<RoleTypeId> RolesThatCanGetObjective { get; set; } = new List<RoleTypeId>();

        public RewardEnum Reward { get; set; } = RewardEnum.None;

        public string ObjectiveString { get; set; } = "Do Absolutely Nothing";

        public int NeededToComplete { get; set; } = 0;

        public ItemType RewardItem { get; set; } = ItemType.None;

        public int RewardXP { get; set; } = 0;
    }
}
