`SLZ.Marrow.Utilities.ObjectPathExtensions, SLZ.Marrow.dll`

`ObjectPathExtensions` is a powerful class due to its `ObjectPath` method. We can use it to generate paths to get the `GameObject`/`Transform` that any component belongs to using UltEvents.

## Replacing the Dummy Script

`ObjectPathExtensions` is a dummy script provided by the ExtendedSDK! This means that it won't do anything if you try to run it in the Unity Editor. It's **highly recommended** to replace it with a functional script, otherwise you'll have to open the game to test each time. As follows:

1. Copy the raw content of `ObjectPathExtensions.cs` (raw insures you only copy the code) ![[Copy Raw File.png]]
2. Find the `ObjectPathExtensions` script underneath your package cache ![[Search for ObjectPathExtensions.png]]
3. Double click to open the script in an editor of your choice, remove everything from it, and paste.
4. Save and close the file. Awesome!
## Example Usage

Here we have a hierarchy of GameObjects:

![[Example Hierarchy.png]]

For demonstration purposes, if we use `ObjectPath` on its `SphereCollider` component, you can see it outputs the path to the `GameObject`:

![[Example Output.png]]

## Combining with `Transform.Find`

[`Transform.Find`](https://docs.unity3d.com/ScriptReference/Transform.Find.html) allows us to get a transform by specifying its path. Similarly, [`GameObject.Find`](https://docs.unity3d.com/ScriptReference/GameObject.Find.html)gets the `GameObject` that a Component belongs to.

Before we can use a path returned by `ObjectPath` with `Transform.Find`, we will need to add a `/` to the start. This will make it search **underneath the root of the scene**, regardless of what `Transform` you provide!

This example demonstrates how you can go from any component (e.g Sphere Collider) to a `Transform`, and then parent something underneath it:

![[TransformFind Example.png]]

### See Also

- [[Finding any Component in scene]] - combined with `Transform.Find`, you can search for components and latch onto their GameObjects or Transforms!
- [[Crawling the Hierarchy]] for information on using `Transform.Find` in UltEvents.