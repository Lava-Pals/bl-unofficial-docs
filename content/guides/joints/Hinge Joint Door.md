> [!CAUTION] This guide was written for Patch 3 and may contain outdated information. 

## This is a simple guide for using joints to create a door!

![[OpeningDoor.gif]]

## Creating a prefab

Make a prefab for the door, inside, add a GameObject called JointDoor, this is used for the door itself. 

If you don't have a frame or anything outside the door that isn't supposed to move, instead add the following components to the root of the prefab.

Add an InteractableHost, Hinge Joint, and a Rigidbody to the JointDoor GameObject. (Or the root)

## The Rigidbody

You can do whatever you want with this, as the setting varies depending on the type of door you're making.

## The InteractableHost

You can just leave this component alone.

## The Hinge Joint

### Add any colliders, models, or grips as children under the JointDoor GameObject.

- You can leave the Connected Rigidbody empty, or you can give the root a Rigidbody, set it to Kinematic, and then connect it to that, but as far as I know, there's not much point in doing that.
- The anchor is what the object will rotate around. You'll usually want to set this to the side of the door, assuming it is a similar model to the one in the GIF.
- Set some of these numbers to 0 or 1, using the "Edit Angular Limits" view to see the rotation. It's important you set this correctly.
- At its current settings, the door has no rotation limit; if you want it to stop moving at a specific rotation, check the "Use Limits" toggle. Under "limits," you can adjust it however you want. Use "Edit Angular Limits" to view the object's limit.
- Lower `Break Force` or `Break Torque` to make your door destructible when positional or rotational force is applied. It's set to infinity by default.

### Here's the settings I use most of the time:

![[HingeJointScreenshot.png]]

### You can play around with the rest of these settings. Although usually just changing the settings I listed works fine though.

If anybody finds mistakes or things I forgot to mention, please message me on discord (sonofforehead), or you can commit to the [`GitHub Repo`](https://github.com/Lava-Pals/bl-unofficial-docs)