# Creating a Basic Spawnable
This guide assumes you have prior experience in Unity.
If you have not already, set up an [Extended SDK](https://github.com/notnotnotswipez/Marrow-ExtendedSDK-MAINTAINED) project.

In this guide, I will explain how to create some melee weapon. For basic spawnables, see [[Basic Spawnable]] For guns, I can't help you. Go watch Stak's video tutorial series on YouTube.

## Layers
You MUST set the appropriate layers for the spawnable. See below for the layer names and which number:

![[layers.png | 450]];

## Root Object
On the root object, add the scripts shown in the image below, and add the values you want. Do not worry about Marrow Entity and center of mass (com) yet.

![[required_scripts.png | 450]]

## Hierarchy Setup
Go into Prefab Mode and setup your hierarchy similar to this:

![[heirarchy.png | 450]]

Once this is done, add the necessary colliders to your spawnable and where you want the center of mass (com). Now you can go back to root and add that to Rigidbody Settings.

## Grips

Create a collider under the parent grip object like the image below. This will be the grip for the object. It does NOT have to be a capsule, it could be a sphere or box collider too.

![[grip_example.png | 450]]

The Z-Axis should be facing the direction you want to grip in
Make sure Is Trigger is checked, and set any radius, height, or any other dimension under the collider script.

Then, in the grip object, SET LAYER TO INTERACTABLE FOR PARENTS AND CHILDREN, and add the following scripts and their values:

![[grip_object_settings.png | 450]]

Grip Settings:
- Check Is Throwable if you want the object to be thrown (true in most cases).
- Movement Axes (Primary should be Z = 1, Secondary should be whichever axis is parallel to the player arm).
- Set different grip options for how it should be held (Multiple hands and Switch Hands are incompatible. FarHover allows for force grabbing).
- Priority (0 means it is gripped before anything else, 1 means neutral).
- Limit should be half of the length of your grip target.

The interactable icon script shows the icon so you know what you're gripping.
Force pull grip script allows for force grabbing. I recommend setting this to Infinity so that force grabbing doesn't feel slow.

## Colliders

If you have not already made colliders for the object, do that now.
Once you have done so, SET LAYER TO DYNAMIC FOR PARENTS AND CHILDREN. This will let the colliders to collide.

![[collider_layers.png | 450]]

## Data

If you have not already created a center of mass (com) or weapon data object, do so now and place it where you want.

Under the weapon data, add the weapon slot script like the image below:

![[weapon_data.png | 450]]

Add your interactable host and grip objects here.

## Marrow Contents

Right-click on your root object and select "Populate Marrow Components" like in the image below:

![[populate_components.png | 450]]

Now navigate to the Marrow Components and click on "Validate" for both of them. A tracker object should appear in your heirarchy.

![[validate.png | 450]]

# Stab, Slash, & Blunt

Under your blade collider (where you want your stabbing or slashing), add an empty game object with the Z-Axis in the direction of the stab:

![[stab_point.png | 450]]

Repeat above if you want slashing:

![[slash_point_1.png | 450]]
![[slash_point_2.png | 450]]

Now, navigate to your root object and add a StabSlash script.

Add a stab point like so:

![[stab_script.png | 450]]

Stab Settings:
- Point Tran (The stab point)
- Point Collider (The blade collider)
- Max Depth (The length of the blade collider)
- Depth resistance mult (How hard it is to keep pushing the stab item)
- Damage (how much damage it does on stab (keep values low if you don't want it to be OP))
- Stab Joint (Always add a stab joint, you don't have to fill it out)

If you are doing slashing, create a slash point:

![[slash_script.png | 450]]

Slash Settings:
- Point Tran (The slash point)
- Point Collider (The blade collider)
- Blade length (The length of the blade collider)
- Max Depth (How far the blade collider goes into the object)
- Damage (how much damage it does on slash [keep values low if you don't want it to be OP])
- Slash Joint (Always add a slash joint, you don't have to fill it out)

ALWAYS FILL OUT BLADE AUDIO. You do not need to put audio clips in, but you have to set each one as none if you are not playing audio.

![[audio_empty.png | 450]]

If you want to do blunt damage, add your blunt colldier to the hilt colliders list:

![[hilt_script.png | 450]]

Blunt Settings:
- Blunt Damage Mult (adds damage to your blunt [keep values low if you don't want it to be OP])

## Pallet Creation

Open up Asset Warehouse, click the plus on the crate, and create a new pallet.

![[asset_warehouse.png | 450]]
![[create_pallet.png | 450]]

Create a spawnable crate

![[create_spawnable_crate.png | 450]]

Add your prefab in the crate menu

![[add_prefab.png | 450]]

Pack your pallet and then open it after packing to move it to the sdk mods folder.

![[pack_platform.png | 450]]

## YIPPEEEE! YOU'RE DONE!

Go test your spawnable. If you have any questions or there are errors in the guide, PLEASE MESSAGE ME ON DISCORD (userrnameee)