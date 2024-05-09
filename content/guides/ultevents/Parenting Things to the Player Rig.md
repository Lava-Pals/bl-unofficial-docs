This guide will teach you how to parent things to the Player Rig (that's your character!). This can be super useful for reading rotations of limbs, invoking methods on the player rig using [`GameObject.SendMessageUpwards`](https://docs.unity3d.com/ScriptReference/GameObject.SendMessage.html) and more.

### What *is* the Player Rig?

The player rig encapsulates all systems that make up your character in Bonelab. That's the physics, avatar, animation, controller tracking data and more.

Throughout this guide there will be references to the `RigManager` - put simply this is the name of the player rig in the scene, as it holds the `RigManager` component that is responsible for itself and all other sub-rigs that make up your character.

## So, Where's the Rig?

If we want to parent things to the rig, we're first going to figure out where it is and what it's called. By opening up Bonelab and having a look at the scene with [UnityExplorer](https://github.com/sinai-dev/UnityExplorer/releases), we can see that the rig is located under the root of the scene and called `[RigManager (Blank)]`:

![[Rig Manager Under Root.png]]

Great! However, if we now try and load into a custom map (not included in the base game) we can see that the rig is actually parented elsewhere. It's underneath in a GameObject named `Default Player Rig [0]`:

![[Rig Manager In Custom Map.png]]

This is *very important* to take into account with your logic, as if you're planning to use `Transform.Find` to do things with the rig, we'll need to account for the different locations.

> [!NOTE] Why is the rig parented differently on custom maps?
> SLZ drops the rig into their own scenes manually so that they can include references to it in their own scripts. However for custom maps, the rig is not included in the SDK and so the game spawns it automatically.

### Section Take-Aways:

- The rig manager is called `[RigManager (Blank)]` and always parented under root on base-game maps.
- For custom maps, the rig manager has the same name but is parented under the `Default Player Rig [0]` GameObject.
- *Side-note:* When in a [Fusion](https://github.com/Lakatrazz/BONELAB-Fusion) lobby, the other player's rigs are named differently and inserted into the scene after the local one - so you don't need to worry about conflicts.

## Parenting to the Rig - Base Game Levels

Let's start with UltEvent logic for parenting to the rig in base game levels.

Create a new GameObject, name it `ParentToRig` and add an `UltEventHolder` component. To test if our logic is working as expected in editor, you can drag the [`[RigManager (Blank)]`](https://github.com/Lava-Pals/bl-unofficial-docs/blob/main/resources/prefabs/%5BRigManager%20(Blank)%5D.fbx) prefab into your scene. Make sure it's directly underneath the root of the scene, and is named exactly as it should be!

Add the logic as scene in the media below:

![[ParentToRig logic Run.gif]]

### Action Explanation

1. `Transform.Find /[RigManager (Blank)]` - This will give us a reference to the RigManager. The `/` at the start tells it to search from the root of the scene - you can swap out `ThingToParent` for any other GameObject and this will still work.
2. `set_parent Return Value 0: Transform.Find(string n)` - We can use our new reference from the previous action to put the `ThingToParent` object underneath the player rig!

## Parenting to the Rig - Any Level

Now we're going to need to use [[conditional statements]] to parent to the rig, regardless of if it's a custom map or not.

As noted from previous steps, we know that:

- `/[RigManager (Blank)]` is the path we need to use to parent to the rig in base game levels.
- `/Default Player Rig [0]/[RigManager (Blank)]` is the path we need to use to parent to the rig on custom maps.

Take your logic from the previous step and create a new GameObject underneath the rig called `ParentToRigIfCustomMap`. We want this to *only* be enabled when we detect that there's a custom map loaded, so make sure it's *disabled* by default.

![[ParentToRig logic 0.png]]

You'll see that if we run it like before, the same thing happens.

![[Any Map - Success.gif]]

However, if the rig isn't found underneath the root of the scene, you'll see that action #1 (`Transform.Find`) returns null, and as a result `set_parent` parents `ThingToParent` to nothing:

![[Any Map - Fail.gif]]

However, as a result of our `Object.Equals` check on action 4, action 5 enables our `ParentToRigIfCustomMap` logic! This means that we can simply add logic that runs when `ParentToRigIfCustomMap` is enabled that'll search for `/Default Player Rig [0]/[RigManager (Blank)]`.

To do this, add a `LifeCycleEvents` component to `ParentToRigIfCustomMap`, and copy the below logic into the enable event:

![[ParentToRigIfCustomMap.png]]

Now when the `ParentToRigIfCustomMap` GameObject is enabled, the following actions will run:

1. `SetActive false` - We disable the GameObject again so that our logic will run again next time something enables the GameObject.
2. `Find /Default Player Rig [0]/[RigManager (Blank)]` - This'll look for the rig manager in root (as denoted by the `/` at the start) and underneath the GameObject that contains it in custom maps.
3. `set_parent Return Value 0: Transform.Find(string n)` - As before, we can use our new reference from the previous action to put the `ThingToParent` object underneath the player rig!

## Resources

- [📂 Prefabs for this guide are available on the repository!](https://github.com/Lava-Pals/bl-unofficial-docs/tree/main/resources/prefabs/Parenting%20Things%20To%20The%20Player%20Rig)
	- [`ParentToRig.prefab`](https://github.com/Lava-Pals/bl-unofficial-docs/blob/3829e73b2635509c1c67ea2116ae4d9dddf18be5/resources/prefabs/Parenting%20Things%20To%20The%20Player%20Rig/ParentToRig.prefab) - Prefab that parents things to the RigManager, as seen in this guide.
	- [`ParentToFeet.prefab`](https://github.com/Lava-Pals/bl-unofficial-docs/blob/3829e73b2635509c1c67ea2116ae4d9dddf18be5/resources/prefabs/Parenting%20Things%20To%20The%20Player%20Rig/ParentToFeet.prefab) - Prefab that parents things to the Locoball.

- [`[RigManager (Blank)].fbx`](https://github.com/Lava-Pals/bl-unofficial-docs/blob/main/resources/prefabs/%5BRigManager%20(Blank)%5D.fbx) - An fbx version that contains the hierarchy for the rig manager. Contains no scripts, but still useful as reference.