using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPObjectives_NWAPI.API.Enums
{
    public enum RewardEnum
    {

        /// <summary>
        /// No reward.
        /// </summary>
        None,
        
        /// <summary>
        /// Give an item on completion.
        /// </summary>
        Item,

        /*
        /// <summary>
        /// Gives an CustomItem on completion.
        /// </summary>
        CustomItem,

        /// <summary>
        /// Give some XP on completion (you must need XPSystem for this to work)
        /// </summary>
        XP
        */
    }
}
