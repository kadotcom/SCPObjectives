using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPObjectives_NWAPI.API.Enums
{
    public enum ObjectiveEnum
    {
        /// <summary>
        /// No objective.
        /// </summary>
        None,
        
        /// <summary>
        /// Kill anyone of any role to complete this objective.
        /// </summary>
        KillAnotherPerson,


        /// <summary>
        /// Escape and become an Private/Conscript to complete this objective.
        /// </summary>
        EscapeFacility,

        /// <summary>
        /// Handcuff anyone to complete this objective.
        /// </summary>
        Handcuff,

    }
}
