
****************************************************

Melt Stone For All Ingots - Update
	ORIGINAL	https://steamcommunity.com/sharedfiles/filedetails/?id=457389706
	O-AUTHOR	wolf4243
	
	UPDATED(3P)	https://steamcommunity.com/sharedfiles/filedetails/?id=1674251348
	U-AUTHOR	echoAwoo
	
****************************************************

Thoughts on rebuilding this mod.
The original mod had replacement definitions for hundreds of items in the game, resulting in their weird effects and bugs. Additionally, it contained a stealth recoloring of the default game ores. All of this has been stripped, boiled down to it's essential modules.

Module 1: Blueprint Declaration
Blueprint_StoneOreToAllIngot.sbc	Contains the settings to tweak and adjust output ratios. Primary declaration of mod.
BlueprintClassesEntry_StoneOreToAllIngot.sbc	Contains a single entry into the BlueprintClasses.sbc file to insert it into the class list. 


Things I am uncertain of:

There doesn't appear to be any solid declaration that this should only occur in Refineries, but it appears to work just fine with Survival Kits, if a little inconsistent (really survival kit, 15 iron to 7 gravel for 500 stone? whatevs, good weak starting item I guess)


Compatibility

No base game files are modified, no collisions from unnecessary declarations.
Collisions possible on redeclared blueprints 'StoneOreToIngotBasic' and 'StoneOreToIngot'.

This should, for the most part, be fully compatible with any other mods unless they change the default stone processing blueprints for survival kits, basic refineries and refineries.


Testing Completed:
"Creative" Survival Singleplayer 
1 Refinery, 1 Large-Large Cargo (1M units stone), 1 Nuclear Reactor (1 uranium)
Time to 0.95 Uranium ~ 1 minute
1 Power Module
Time to 0.90 Uranium ~ 5 minutes
2 Power Modules
Time to 0.88 Uranium ~ 10 minutes

If 3 or 4 end up being power positive I am still satisfied.


Change Notes
	Increased nickel output by +0.02/kg
	Changed refinery processing time 0.1 -> 0.01

	Removed unnecessary BlueprintClasses entry
	Added mod to survival kits
	Survival kits now process 1 unit stone at 0.1 (10/s) instead of 500 at 25 (20/s)
	Adjusted output values to be vanilla-like. Higher iron nickel output.
	