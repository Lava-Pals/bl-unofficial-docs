!!! REQUIRES THE [EXTENDED SDK](https://github.com/notnotnotswipez/Marrow-ExtendedSDK-MAINTAINED) !!!

Levels can use a few Player Marker decorator scripts to customize the player's experience in a level. 

## Player Avatar Decorator
The **Player Avatar Decorator** script sets the avatar of the player upon loading into the level. Simply add the component to the Player Marker in your level, add the Player Marker reference, and choose an override avatar.

![[PlayerAvatarDecorator.gif]]

---
## Player Health Decorator
The **Player Health Decorator** script configures the mortality of the player. It also includes an UltEvent to be invoked upon the player's death.

To setup, add the component to your Player Marker GameObject and set the Player Marker reference, then choose your options:

- **Reload Level On Death** - Self explanatory, on by default for mod levels
- **Health Mode** - Specifies how the player's health is handled
	- **Invincible** - The player can receive damage, but cannot die
	- **Mortal** - The player can receive damage and be killed. They have a chance to revive themself after running out of health, during the `Death Time` period. Default for mod levels
	- **Instant Death** - The player can receive damage and can be killed, but has no chance to revive themself
		***NOTE:*** Instant Death mode is currently bugged as of Patch 6 of BONELAB. It causes the player to be unable to die after the first death. Instead, use Mortal mode with a short Death Time
- **Death Time** - The amount of scaled time in seconds after running out of health for which the player will be in slo-mo with a chance to revive themself by killing an NPC. Defaults to 5 seconds
- **On Player Death ()** - An UltEvent to be invoked upon player death. This is useful for increasing a death counter, loading a different level, respawning NPCs, or whatever else you may wish to do with it. If you have no use for it, you can leave it blank

![[PlayerHealthDecorator.png]]

A hidden property of the Player Health Decorator is the fact that it will apply the rotation of the Player Marker to the spawned player. This is useful if your want the player to spawn facing an a direction other than Y0, but rotating on the X or Z axis ***WILL*** cause the player rig to malfunction.

---
## Player Leasher
The **Player Leasher** script restricts the player from moving a certain range from the Player Marker. This is used in level **00 - Main Menu**.

First, add the component to the Player Marker GameObject and set the Player Marker reference. Then, set the minimum and maximum leash distances (in meters).

The **Min_leash** is the radius within which the player can move freely. The **Max_leash** is the radius at which the player is fully restricted. As the player moves beyond the minimum distance, they will feel more and more resistance until reaching the maximum distance. 
![[PlayerLeasher.png]]