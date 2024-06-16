namespace SCPObjectives.Commands
{
    using CommandSystem;
    using Exiled.API.Features;
    using RemoteAdmin;
    using SCPObjectives.API.Features;
    using System;

    [CommandHandler(typeof(ClientCommandHandler))]
    public class ObjectiveCommand : ICommand
    {
        public string Command { get; } = "objectives";

        public string[] Aliases { get; } = { "listobjectives" };

        public string Description { get; } = "Lists every objective you currently have.";

        public bool SanitizeResponse => false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is not PlayerCommandSender)
            {
                response = "This command can only be ran by a player!";
                return true;
            }

            response = Builder.BuildObjectiveString(Player.Get(sender));
            return true;
        }
    }

}
