---
title: Traversing the Hierarchy with Transform.Find
---
#wip

> [!NOTE] Work in progress!
> This page is missing Prefabs.

This guide covers how to use [`Transform.Find`](https://docs.unity3d.com/ScriptReference/Transform.Find.html) to find objects in the scene - including info on how to abuse its undocumented behaviour.

This can be very useful for [[Parenting Things to the Player Rig]], as well as for other scenarios that require references to GameObjects inaccessible out of the editor.

## Traversing the Ancestry

You can use the `../` syntax to traverse to the parent of an object. This can be very useful for getting references to GameObjects that you can't access in editor.

The below gif showcases using this to parent an object (`ParentToFloop`) to another one that exists inside of the parent (`Floop`):

![[TransformFindParent.gif]]

## Traversing from the Scene Root

Similarly, appending `/` to the start of a path will base your path on the *root of the scene*.

This example showcases using `/` at the start to search the root, look inside of the `Floop` GameObject, then finally parent to `Bar`:

![[TransformFindRoot.gif]]