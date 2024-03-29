# SCPObjectives
SCPObjectives is an EXILED and NWAPI plugin that adds objectives to SCP:SL.

# Features
- Customizable objectives.
- Item, CustomItem and XP rewards for completing objectives.
- [XPSystem](https://github.com/RowpannSCP/XP) support for rewarding XP in both versions.
- [NWAPI-CustomItems](https://github.com/NWAPI-CustomItems/API) support for rewarding CustomItems in the NWAPI version.

# Installation

### EXILED
1. Install the 'SCPObjectives.dll' file from the [GitHub Releases](https://github.com/kadotcom/SCPObjectives/releases/latest).

2. Put the 'SCPObjectives.dll' file in the ```EXILED/Plugins``` folder, then either restart the server, or start the server if it's offline.
### NWAPI
1. Install the 'SCPObjectives-NWAPI.dll' file from the [GitHub Releases](https://github.com/kadotcom/SCPObjectives/releases/latest).

2. Also install the 'dependencies-nwapi.zip' folder from the [GitHub Releases](https://github.com/kadotcom/SCPObjectives/releases/latest).

3. Also install the NWAPI version for [XPSystem](https://github.com/RowpannSCP/XP) and [NWAPI-CustomItems](https://github.com/NWAPI-CustomItems/API) so no complications arise, as if they aren't installed, it puts an error in console.

4. Put the 'SCPObjectives-NWAPI.dll', 'NWAPI.CustomItem.API.dll' and 'XPSystem-nw.dll' file in the ```PluginAPI/plugins/global```/```PluginAPI/plugins/{port}``` folder.

5. Unzip the 'dependencies-nwapi.zip' file and move all the contents into the ```PluginAPI/plugins/global/dependencies```/```PluginAPI/plugins/{port}/dependencies``` folder.
   
6. After installing everything, either restart the server, or start the server if it's offline.

# API
The SCPObjectives API is built within the plugin but they're different between EXILED and NWAPI, to use the API, depending on what plugin framework you're using, add either the EXILED, or NWAPI plugin for SCPObjectives as a reference.
