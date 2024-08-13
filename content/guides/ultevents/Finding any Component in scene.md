> [!info] This guide covers a lot of ground, so don't feel discouraged if it's too much. You're free to ask for help over in the Bonelab Discord Server, or try out some other guides first while you get your footing. Best of luck!

This guide will cover 3 very useful methods you can use in your logic:

- `System.Type.GetType`
- `UnityEngine.Object.FindObjectOfType`
- `MarrowUtilities.ObjectPath`

## About FindObjectOfType

Unity provides us with a method called [`FindObjectOfType`](https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html) that we can use to search for specific components. In this guide, we'll use it to locate the `PlayerMarker` as an example!

That's this fella if you were wondering - it marks the player's spawn point.

![[Player Marker.png]]

## Getting the Type

Start by making a new `UltEventHolder`, searching `System.Type` into the static method type picker and clicking on the `GetType` override that takes 3 arguments:

![[GetType.png]]

I ticked `throwOnError` so that we get an error in the console if it doesn't work, and also ticked `ignoreCase` because case sensitivity is irrelevant.

Now find out what the name of the type we need is. If you have ExtendedSDK installed into your project, we can snatch it from the dummy script. Switch the search to **In Packages** along the top of your project window, and search `PlayerMarker`:

> [!NOTE] Note
> Not all ExtendedSDK scripts will be underneath your project's package cache. If you can't find the script, try switching the search filter to 'In Assets' or 'All.'

![[PlayerMarkerSearch.png]]

Great! Click the PlayerMarker script and have a look at it in the inspector.

![[StealingFromScript.png]]

Start by taking the **namespace** and **class name** from the code. Look for `namespace` in the code and copy the text afterwards. Then look for `public class` and steal the class name that follows, leaving out anything after the colon.

Also make note of the **assembly** - we'll need this in a moment.

Great! Putting the namespace in-front of the class name will give us **the full name of your class**, which is what we will need in a minute. Combine like so:

![[StealingFromScript2.png]]

> [!Info] Still can't find the class you need?
> It may be an **engine type**, which means it won't be part of your project.
> 
> ![[CantFindCamera.png]]
> 
> In this case, classes, namespaces and assemblies can be found on the [Unity scripting reference](https://docs.unity3d.com/2021.3/Documentation/ScriptReference).
> 
> Opening a page for any of the class we can find all the info we need.
> 
> ![[StealingFromDocs.png]]

If we feed the classes **full name** into the `typeName` field, and invoke the `UltEventHolder`, we'll get an error:

![[GetTypeFilled.png]]
![[GetTypeException.png]]

Right now, this function is trying to look for `SLZ.Marrow.SceneStreaming.PlayerMarker` underneath UltEvents. To fix this, we need to also give it the correct **assembly name** from earlier.

Simply add a comma and type the assembly name, like so:
`SLZ.Marrow.SceneStreaming.PlayerMarker, SLZ.Marrow`

![[GetTypeFilledCorrectly.png]]

Now invoke the UltEventHolder and you'll see that no errors appear in the console. Sweet!
## Using FindObjectOfType

Now that we have the type, we can filter through the scene for an object that matches it.

Add a new action with `UnityEngine.Object` `FindObjectOfType`. We can use our return value from the previous step, and just like that it'll find the first component in the scene (in this case our `PlayerMarker`!)

![[FindObjectOfType.png]]

Make sure you have a `GameObject` with your component on it in the scene, or go ahead and make one if you don't. I went ahead and inserted a `PlayerMarker` into mine.

If we use `UnityEngine.Debug.Log` to output to the console and invoke our `UltEvent` now, you should see that it successfully found the `PlayerMarker` in the scene!

![[AddLogging.png]]
![[SuccessfulLog.png]]
## Getting the Transform from our component with `ObjectPath`

This is unfortunately where our editor testability ends. Select `SLZ.Marrow.Utilities.ObjectPathExtensions` from the static method type picker:

![[ObjectPathExtensionsSearch.png]]

In this case we have a component, so **make sure you select the overload that takes in a Component!**

![[ObjectPathMethod.png]]

This method is allows us to pass in any component, and returns out a **path** to it separated out by slashes.

Feed the return value from `FindObjectOfType` into `ObjectPath`. Since there's no way to cast `Object` to `Component` in UltEvents, you'll need the to use the Debug menu to do this.

> [!info] See [[Using GetComponent in UltEvents#Using GetComponent with methods that don't take a generic Component (THE RED)]] for info on exploiting the debug menu for this purpose!  

![[ObjectPathWithTheRed.png]]

The paths returned by `ObjectPath` look something like this:
- `Spawnable [0]/Art/Main`
- `ObjectPathTest/[0]/Grips/BoxGrip`

Or in our case with the Player Marker, it should look something like this in most of SLZ's scenes:
- `//-----ENVIRONMENT/Player Marker`

This is perfect! Now that we have an exact path to the player marker, we can feed it into `Transform.Find` to convert our path into a Transform, then parent underneath it to get the location of the Player Marker.

To tell `Transform.Find` to search under the **root of our scene**, we need to add `/` to the start of the path. This is very important!

We can achieve this by using the `string.Format` method. Feed the return value from ObjectPath into `string.Format`, and then type `/{0}`. The method is going to replace `{0}` with whatever we tell it to.

Now that our path is correct, feeding it into `Transform.Find` will give us the Transform!

The following example will show the final logic being used to locate a player marker in the scene, parent something underneath it, and then recenter:

![[FullLogic.png]]