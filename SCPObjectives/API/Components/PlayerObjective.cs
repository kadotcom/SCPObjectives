using Exiled.API.Features;

namespace SCPObjectives.API.Components
{
    public class PlayerObjective
    {
        public Player player;

        public Objective objective;

        public int Current = 0;

        public bool IsCompleted = false;
    }
}
