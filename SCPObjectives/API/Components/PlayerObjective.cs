using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCPObjectives.API.Components
{
    public class PlayerObjective : MonoBehaviour
    {
        public Player player;

        public Objective objective;

        public int Current = 0;

        public bool IsCompleted = false;
    }
}
