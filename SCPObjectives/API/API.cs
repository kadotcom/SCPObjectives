using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using SCPObjectives.API.Components;
using SCPObjectives.API.Enums;
using System.Collections.Generic;
using XPSystem;

namespace SCPObjectives.API
{
    public class API
    {
        /// <summary>
        /// List of PlayerObjective (Objectives) that are currently.
        /// </summary>
        public List<PlayerObjective> Objectives;

        /// <summary>
        /// List of players who has received objectives.
        /// </summary>
        public List<Player> PlayersWhoHasReceivedObjectives;

        public API() {
            Init();
        }

        private void Init()
        {
            Objectives = new List<PlayerObjective>();
            PlayersWhoHasReceivedObjectives = new List<Player>();
            if(Plugin.Instance.Config.Debug)
                PluginAPI.Core.Log.Debug("SCPObjectivesAPI has been enabled!");
        }

        public void Clear()
        {
            Objectives.Clear();
            PlayersWhoHasReceivedObjectives.Clear();
        }

        /// <summary>
        /// Gets a random objective from the Config.
        /// </summary>
        /// <param name="p">player</param>
        /// <returns></returns>
        public Objective GetRandomObjective(Player p)
        {
            Objective o = Plugin.Instance.Config.Objectives.RandomItem();
            if (o.IsRoleSpecific && !o.RolesThatCanGetObjective.Contains(p.Role.Type))
            {
                int reattempts = 0;
                while(!o.RolesThatCanGetObjective.Contains(p.Role.Type) || reattempts < 15)
                {
                    o = Plugin.Instance.Config.Objectives.RandomItem();
                    reattempts++;
                }
            }
            return o;
        }

        /// <summary>
        /// Gets all the players objective.
        /// </summary>
        /// <param name="p">player</param>
        /// <returns></returns>
        public List<PlayerObjective> GetPlayerObjectives(Player p)
        {
            List < PlayerObjective > playerObjectives = new List < PlayerObjective >();

            foreach (PlayerObjective po in Objectives)
            {
                if(po.player == p)
                {
                    playerObjectives.Add (po);
                }
            }

            return playerObjectives;
        }

        /// <summary>
        /// Gets the total amount of objectives that a player has.
        /// </summary>
        /// <param name="p">player</param>
        /// <returns>playerobjective</returns>
        public int GetAmountObjectives(Player p)
        {
            int playerObjectives = 0;

            foreach (PlayerObjective po in Objectives)
            {
                if (po.player == p)
                {
                    playerObjectives++;
                }
            }

            return playerObjectives;
        }

        /// <summary>
        /// Gets the player's PlayerObjective instance from the objectives enum, can be null.
        /// </summary>
        /// <param name="p">player</param>
        /// <param name="o">objective</param>
        /// <returns>playerobjective</returns>
        public PlayerObjective GetPlayerObjectiveFromEnum(Player p, ObjectiveEnum o)
        {
            PlayerObjective playerObjective = null;
            foreach (PlayerObjective po in Objectives)
            {
                if (po.player == p && po.objective.ObjectiveType == o)
                {
                    playerObjective = po;
                }
            }
            return playerObjective;
        }

        /// <summary>
        /// Checks if a player has an objective.
        /// </summary>
        /// <param name="p">player</param>
        /// <param name="o">objective</param>
        /// <returns>true/false</returns>
        public bool PlayerHasObjective(Player p, ObjectiveEnum o)
        {
            bool r = false;
            foreach(PlayerObjective po in Objectives)
            {
                if (po.player == p && po.objective.ObjectiveType == o)
                {
                    r = true;
                }
            }
            return r;
            
        }

        /// <summary>
        /// Marks an objective as completed.
        /// </summary>
        /// <param name="p">PlayerObjective</param>
        public void MarkObjectiveAsComplete(PlayerObjective p)
        {
            string hint = "";

            if (Objectives.Contains(p) && !p.IsCompleted)
            {
                if (p.objective.Reward == Enums.RewardEnum.Item)
                {
                    hint = Features.Builder.BuildHint($"Completed {p.objective.ObjectiveString}!\n+{p.objective.RewardItem.ToString()}", "36fe04ff");
                    p.player.AddItem(p.objective.RewardItem);
                }
                else if (p.objective.Reward == Enums.RewardEnum.XP)
                {
                    if (Main.Instance == null)
                    {
                        PluginAPI.Core.Log.Error("Cannot grant XP as XPSystem doesn't exist, please install the plugin.");
                        return;
                    }
                    hint = Features.Builder.BuildHint($"Completed {p.objective.ObjectiveString}!\n+{p.objective.RewardXP.ToString()} EXP", "36fe04ff");
                    XPSystem.API.Extensions.AddXP(XPSystem.API.Extensions.GetLog(p.player.ReferenceHub), p.objective.RewardXP);
                }else if(p.objective.Reward == RewardEnum.CustomItem)
                {
                    CustomItem? customItem = CustomItem.Get(p.objective.RewardCustomItem);

                    if (customItem == null)
                    {
                        PluginAPI.Core.Log.Error($"CustomItem ID {p.objective.RewardCustomItem} doesn't exist.");
                        return;
                    }

                    customItem.Give(p.player);
                    hint = Features.Builder.BuildHint($"Completed {p.objective.ObjectiveString}!\n+{customItem.Name}", "36fe04ff");

                }

                p.player.ShowHint(hint, 5);
                p.IsCompleted = true;
            }
        }


        /// <summary>
        /// Creates a PlayerObjective and adds it to the 'Objectives' list.
        /// </summary>
        /// <param name="objective">objective</param>
        /// <param name="player">player</param>
        public void AssignObjective(Objective objective, Player player)
        {
            PlayerObjective playerObj = new PlayerObjective();

            if(objective != null)
            {
                if (objective.IsRoleSpecific && !objective.RolesThatCanGetObjective.Contains(player.Role.Type))
                {
                    if (Plugin.Instance.Config.Debug)
                    {
                        PluginAPI.Core.Log.Warning("Cannot assign objective \"" + objective.ObjectiveString + "\" to player " + player.DisplayNickname + " as the objective is role specific and the player don't have the right role.");
                    }

                    return;
                }
                playerObj.player = player;
                playerObj.objective = objective;
                playerObj.Current = 0;
                if(Objectives == null)
                {
                    if (Plugin.Instance.Config.Debug)
                    {
                        PluginAPI.Core.Log.Warning("For some reason, it appears the API wasn't initialized, so it will be initialized now.");
                    }
                    Init();
                }
                Objectives.Add(playerObj);
            }
        }

        
    }
}
