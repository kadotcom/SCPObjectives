# SCPObjectives
SCPObjectives is an EXILED plugin that adds objectives to SCP:SL.

# Features
- Customizable objectives.
- Item, CustomItem and XP rewards for completing objectives.
- [XPSystem](https://github.com/RowpannSCP/XP) support for rewarding XP.

# Installation

1. Install the 'SCPObjectives.dll' file from the [GitHub Releases](https://github.com/kadotcom/SCPObjectives/releases/latest).

2. Put the 'SCPObjectives.dll' file in the ```EXILED/Plugins``` folder, then either restart the server, or start the server if it's offline.

3. If you get an error related to XPSystem missing, ignore it unless you intended to have XP as an reward for objectives, the plugin will work as normal, if you do intend to have an XP reward, then install XPSystem.  

# Setup
When the config get initialized, you'll see a few stuff, but this will focus on setting up Objectives, how Objectives work in this plugin is that you set the Objectives that can be given in the config. You do this by finding the ```objectives``` list in the config, this is what it should look like initially
```yaml
  objectives:
  - objective_type: EscapeFacility
    is_role_specific: true
    roles_that_can_get_objective:
    - ClassD
    - Scientist
    reward: Item
    objective_string: 'Escape the facility'
    needed_to_complete: 1
    reward_item: KeycardScientist
    reward_custom_item: 0
    reward_x_p: 0
  - objective_type: DealDamage
    is_role_specific: false
    roles_that_can_get_objective: 
    reward: Item
    objective_string: 'Deal damage'
    needed_to_complete: 250
    reward_item: None
    reward_custom_item: 0
    reward_x_p: 0
  - objective_type: Handcuff
    is_role_specific: false
    roles_that_can_get_objective: 
    reward: CustomItem
    objective_string: 'Handcuff someone'
    needed_to_complete: 1
    reward_item: None
    reward_custom_item: 1
    reward_x_p: 0
```
