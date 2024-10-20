# Setup
In a project with the [Extended SDK](https://github.com/notnotnotswipez/Marrow-ExtendedSDK-MAINTAINED) installed, make a Game Object with the Seat script, and a box collider set to Trigger. Add two empty Game Objects as children under the seat called Foot "FootLf" and "FootRt." In the Seat script, assign the root Rigidbody to the SeatRb (assuming you're making the seat in a prefab).

![[SeatHierachy.png|200]]

## Settings
These settings change depending on what you're going for, I like to use the settings shown in the screenshot below, if you want to use these, there's a preset you can use [here](https://github.com/Lava-Pals/bl-unofficial-docs/blob/3829e73b2635509c1c67ea2116ae4d9dddf18be5/resources/presets/Seat/Seat.preset), or you can just copy what's shown in the screenshot.

The FootLf and FootRt determine where the players feet go, the blue arrow being where the foot points.

![[SeatExample.png|400]]