using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPObjectives.API.Enums
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
        /// Be on surface when someone escapes to complete this objective.
        /// </summary>
        AssistEscape,

        /// <summary>
        /// Deal damage to anyone to complete this objective.
        /// </summary>
        DealDamage,

        /// <summary>
        /// Handcuff anyone to complete this objective.
        /// </summary>
        Handcuff,

        /// <summary>
        /// Activate a generator to complete this objective.
        /// </summary>
        EnableGenerators,

        /// <summary>
        /// Get into and successfully escape the pocket dimension to complete this objective.
        /// </summary>
        EscapePocketDimension,

        /// <summary>
        /// Pick up any item to complete this objective.
        /// </summary>
        PickUpItem,

        /// <summary>
        /// Open a gate to complete this objective.
        /// </summary>
        AccessGate,

        /// <summary>
        /// Drink a cola to complete this objective.
        /// </summary>
        DrinkCola,
    }
}
