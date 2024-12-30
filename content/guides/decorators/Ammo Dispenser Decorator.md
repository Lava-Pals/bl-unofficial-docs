!!! REQUIRES THE [EXTENDED SDK](https://github.com/notnotnotswipez/Marrow-ExtendedSDK-MAINTAINED) !!!

The Bullet Banker (the ammo dispenser in BONELAB) can be customized to fit for Tac-Trial style mod levels, or similar cases where you want the player to only have a certain amount of ammo made available to them.

To setup, create a CrateSpawner of the **Bullet Banker** spawnable, and add the **Ammo Dispenser Decorator** script to the GameObject. Then, configure as needed.

- Options include:
	- **Infinite** **Light**/**Medium**/**Heavy** - Whether or not there should be an infinitely dispensable amount of ammo boxes per each ammo type
	- **Count** **Light**/**Medium**/**Heavy** - The amount of ammo boxes that can be dispensed for each ammo type, if it is not set to be infinite
	- Rate Single - If this option is enabled, the buttons will dispense one ammo box for each time the buttons are pushed. If it is disabled, the buttons will continuously dispense ammo boxes as long as they are being pushed, until they run out. This can be changed any time by the player using the button toggle on the back of the Bullet Banker

For reference:

| Ammo type | Rounds per box |
| --------- | -------------- |
| Light     | 40             |
| Medium    | 60             |
| Heavy     | 15             |

![[AmmoDispenserDecorator.png]]