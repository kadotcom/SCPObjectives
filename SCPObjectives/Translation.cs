using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPObjectives
{
    public class Translation : ITranslation
    {
        [Description("The first tagline that will appear when a Objective is completed.")]
        public string ObjectiveCompletedHint { get; set; } = "Completed";
        
        [Description("The tag that will appear when you check your objectives and see that an objective is completed.")]
        public string ObjectiveCompletedCheck { get; set; } = "COMPLETED";
    }
}
