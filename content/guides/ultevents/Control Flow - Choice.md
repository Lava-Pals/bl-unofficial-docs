If (equal) statements are used a lot when it comes to making UltEvents logic (or well, any kind of logic).

UltEvents don't have a way to do a choice statement within an event. What we do is compare the values we want (using [`object.Equals`](https://learn.microsoft.com/en-us/dotnet/api/system.object.equals?view=net-8.0). Explanation below), and use the returned boolean value and apply it onto another GameObject using [`GameObject.SetActive`](https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html). 

We utilize the [LifeCycleEvents](https://kybernetik.com.au/ultevents/api/UltEvents/LifeCycleEvents/)  script that is built-in within the UltEvents package to know when an object is enabled and disabled. We generally want that GameObject to be disabled in editor, so the enable event doesn't go off when initialized. 

When the GameObject is enabled, that means the value is `true`. When it's disabled, that means the value is `false`.

Time for an example. As always, make a new prefab and follow along. For the sake of the example, we're just going to compare a name of an GameObject to antoher string. Make sure to briefly go over [[Debugger]] before proceeding.

Add your UltEvent Holder, and add a new event to it.
Open up the method menu and locate Object.name on your GameObject. 
- Can be found here: `GameObject > Base Types > UnityEngine.Object > string name` - We want to get it.
You know have the name of the object. You can now add another event, and find [`object.Equals`](https://learn.microsoft.com/en-us/dotnet/api/system.object.equals?view=net-8.0)
-  Can be found here: `Anything > Base Types > object > bool Equals (object objA, object objB)`
For the first object, we leave it as is - the return value (that points to the name).
For the second object, we want to set it as a string using the [[Debugger]]. You can now go back to your normal inspector and set the string that can you want to compare the name to.
Now we make a new GameObject and add the [LifeCycleEvents](https://kybernetik.com.au/ultevents/api/UltEvents/LifeCycleEvents/) script to it. Let's call it `ifTrue`. We want to set it as a target in a new event and set the method to [`GameObject.SetActive`](https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html) and use the return value from the Equals method we used.

Here's what it should eventually look like:

![[SimpleChoice.png]]


That's it! You've successfully made your first UltEvent if statement! The `ifTrue` GameObject will get enabled when the value is `true` (hence invoking the Enable Event on the [LifeCycleEvents](https://kybernetik.com.au/ultevents/api/UltEvents/LifeCycleEvents/) script) and will get disabled when the value is `false` (hence invoking the Disable Event on the script).
