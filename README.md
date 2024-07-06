# SCPObjectives
SCPObjectives is an EXILED plugin that adds objectives/quests to SCP:SL.

# Features
- Customizable objectives.
- Item, CustomItem and XP rewards for completing objectives.
- [XPSystem](https://github.com/RowpannSCP/XP) support for rewarding XP.

# Installation

1. Install the 'SCPObjectives.dll' file from the [GitHub Releases](https://github.com/kadotcom/SCPObjectives/releases). (If you are on EXILED 9, download the pre-release version)

2. Put the 'SCPObjectives.dll' file in the ```EXILED/Plugins``` folder, then either restart the server, or start the server if it's offline.

3. If you get an error related to XPSystem missing, ignore it unless you intend to have XP as an reward for objectives, the plugin will work as normal, if you do intend to have an XP reward, then install XPSystem.

# How To View Objectives
When you spawn initially, if that's either when the round starts, or at the next spawnwavwe, you will be given objectives if ```assign_objectives``` is enabled (which it is by default), when you are given these objectives, it will print a message in the player console saying your objectives. To get an updated objective list, just run either ```.objectives```, or ```.listobjectives``` in the player console.

# Settting Up New Objectives
This is a step-by-step tutorial on how to create objectives, I plan to make some tutorial videos soon for those who would rather watch a tutorial on how to create new objectives.

When the config get initialized, you'll see a few stuff, but this will focus on setting up Objectives, how Objectives work in this plugin is that you set the Objectives that can be given in the config. You do this by finding the ```objectives``` list in the config, this is what it should look like initially.
```yaml
  objectives:
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: EscapeFacility
    # Determines if a certain role can get/complete the objective.
    is_role_specific: true
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective:
    - ClassD
    - Scientist
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - Item
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: 'Escape the facility'
    # The amount that is needed to complete an objective.
    needed_to_complete: 1
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: KeycardScientist
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 0
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: Handcuff
    # Determines if a certain role can get/complete the objective.
    is_role_specific: false
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective: 
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - CustomItem
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: 'Handcuff someone'
    # The amount that is needed to complete an objective.
    needed_to_complete: 1
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: None
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 1
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
```
Each value is explained in the comment above it (e.g, needed_to_complete is the amount that is needed to complete an objective), here is a template for objectives:
```yaml
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: None
    # Determines if a certain role can get/complete the objective.
    is_role_specific: false
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective: 
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - None
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: ''
    # The amount that is needed to complete an objective.
    needed_to_complete: 1
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: None
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 0
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
```
So, to add a new objective, you copy the template, or one of the objectives provided, and paste it below the last objective, so for the default config, this is how it should look:
```yaml
  objectives:
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: EscapeFacility
    # Determines if a certain role can get/complete the objective.
    is_role_specific: true
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective:
    - ClassD
    - Scientist
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - Item
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: 'Escape the facility'
    # The amount that is needed to complete an objective.
    needed_to_complete: 1
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: KeycardScientist
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 0
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: Handcuff
    # Determines if a certain role can get/complete the objective.
    is_role_specific: false
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective: 
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - CustomItem
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: 'Handcuff someone'
    # The amount that is needed to complete an objective.
    needed_to_complete: 1
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: None
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 1
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: None
    # Determines if a certain role can get/complete the objective.
    is_role_specific: false
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective: 
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - None
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: ''
    # The amount that is needed to complete an objective.
    needed_to_complete: 1
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: None
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 0
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
```
Now, obviously, an uncompletable objective can't be assigned, so let's change some of the values in here. Let's start with the ObjectiveType, there is, currently, 9 actual objectives types, those are listed below:
### ObjectiveTypes
```csharp
// Kill anyone of any role to complete this objective.
KillAnotherPerson
// Escape and become an Private/Conscript to complete this objective.
EscapeFacility
// Deal damage to anyone to complete this objective.
DealDamage
// Handcuff anyone to complete this objective.
Handcuff
// Activate a generator to complete this objective.
EnableGenerators
// Get into and successfully escape the pocket dimension to complete this objective.
EscapePocketDimension
// Pick up any item to complete this objective.
PickUpItem
// Open a gate to complete this objective.
AccessGate
// Drink a cola to complete this objective.
DrinkCola
```
So, for this example, let's make the objective completeable by dealing damage to someone.
```yaml
  objective_type: DealDamage
```
Now, for this example, I won't enable ```is_role_specific```, but there is an example within the config, so let's go to setting a reward.

As of right now, there are four actual reward types, those are listed below:
### RewardTypes
```csharp
// Give an item on completion.
Item
// Gives an CustomItem on completion.
CustomItem
// Give some XP on completion (you must need XPSystem for this to work)
XP
// Gives MTF/CI tickets on completion depending on what team the player who completed it is on.
Tickets
```
For this example, let's make it so it rewards an item, you can add more rewards by copying the entry and adding another one, just do note, if you add more than one reward, the user will get all rewards you put, not just one of the rewards:
```yaml
reward:
- Item
```
So now it's time to give the objective a name, I am gonna go with something simple for the example:
```yaml
objective_string: 'Deal Damage'
```
So now let's set the amount that is needed to complete an objective, so normally, the current amount will increase by one, but for the deal damage objective, it will increase by how much damage is caused. So let's set it to something like 350.
```yaml
needed_to_complete: 350
```
Now, it's time to actually set the item that will be given on completion, so for rewarding CustomItems, it goes based on uint ID for the CustomItem and the ```reward_custom_item``` variable, and for rewarding XP, it goes based on an Integer and the ```reward_x_p``` variable, but for rewarding items, it goes based on an ItemType and ```reward_item``` variable, so for this example, let's make it give a Coin on completion:
```yaml
reward_item: Coin
```
And now... we are done! So here is what the final result looks like in this case:
```yaml
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: DealDamage
    # Determines if a certain role can get/complete the objective.
    is_role_specific: false
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective: 
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - Item
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: 'Deal Damage'
    # The amount that is needed to complete an objective.
    needed_to_complete: 350
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: Coin
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 0
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
```
And this is how it should look like in the ```objectives``` list:
```yaml
  objectives:
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: EscapeFacility
    # Determines if a certain role can get/complete the objective.
    is_role_specific: true
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective:
    - ClassD
    - Scientist
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - Item
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: 'Escape the facility'
    # The amount that is needed to complete an objective.
    needed_to_complete: 1
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: KeycardScientist
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 0
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: Handcuff
    # Determines if a certain role can get/complete the objective.
    is_role_specific: false
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective: 
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - CustomItem
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: 'Handcuff someone'
    # The amount that is needed to complete an objective.
    needed_to_complete: 1
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: None
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 1
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
  -
  # The objective that you need to complete (read the GitHub README for each ObjectiveType)
    objective_type: DealDamage
    # Determines if a certain role can get/complete the objective.
    is_role_specific: false
    # List of RoleTypeId's that can get/complete the objective if is_role_specific' is enabled.
    roles_that_can_get_objective: 
    # The reward you'll get once the objective is completed (read the GitHub README for each RewardType)
    rewards:
    - Item
    # The name of the objective (e.g, if your objective is on escaping, you can call it something like 'Escape The Facility')
    objective_string: 'Deal Damage'
    # The amount that is needed to complete an objective.
    needed_to_complete: 350
    # The ItemType you'll get if you complete an objective (if reward is set to Item)
    reward_item: Coin
    # The CustomItem (by ID) you'll get if you complete an objective (if reward is set to CustomItem)
    reward_custom_item: 0
    # The amount of XP you'll get if you complete an objective. (if reward is set to XP)
    reward_x_p: 0
```
After you are done, save the config and, if the server is online, restart the server, or, if it's offline, start the server and the objective should be in-game.
