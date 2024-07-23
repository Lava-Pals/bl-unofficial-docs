> [!info] This guide covers a lot of ground, so don't feel discouraged if it's too much. You're always free to ask for help over in the Bonelab Discord Server, or try out some other guides first while you get your footing. Best of luck!

This guide will cover 3 very useful methods you can use in your logic:

- `System.Type.GetType`
- `UnityEngine.Object.FindObjectOfType`
- `MarrowUtilities.ObjectPath`

## About FindObjectOfType

Unity provides us with a method called [`FindObjectOfType`](https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html) that we can use to search for components of a specific type. In this guide, we'll be using it to locate the `PlayerMarker` as an example!

That's this fella if you were wondering - the player spawn point.

![[Player Marker.png]]

## Getting the Type

Start by making yourself a new `UltEventHolder`, searching `System.Type` into the static method type picker and clicking on the `GetType` override that takes 3 arguments:

![[GetType.png]]

I went ahead and ticked `throwOnError` so that we get an error in the console if it doesn't work, and also ticked `ignoreCase` because we don't care about case sensitivity.

Now let's find out what the name of the type we need is. If you have ExtendedSDK installed into your project, we can snatch it from the dummy script. Switch the search to **In Packages** along the top of your project window, and search for the `PlayerMarker`:

> [!NOTE] Note
> Not all ExtendedSDK scripts will be underneath your project's package cache. If you can't find the script, try switching the search filter to 'In Assets' or 'All.'

![[PlayerMarkerSearch.png]]

Great! Click the PlayerMarker script and have a look at it in the inspector.

![[StealingFromScript.png]]

We'll need to start by taking the **namespace** and **class name** from the code. Search for `namespace` in the code and copy the text afterwards. Then look for `public class` and steal the class name that follows, leaving out anything after the colon.

Great! Now we can combine the namespace and class name together to get the full name of our class, like so:

![[StealingFromScript2.png]]

If we feed that into the `typeName` field, and invoke the `UltEventHolder`, we'll get an error:

![[GetTypeFilled.png]]
![[GetTypeException.png]]

That's because we also need to specify the assembly name that we got earlier (this is because it's incorrectly targeting the `UltEvent` assembly).

To fix this, add a comma and type the assembly name like so:
`SLZ.Marrow.SceneStreaming.PlayerMarker, SLZ.Marrow`

![[GetTypeFilledCorrectly.png]]

Now if you invoke the UltEventHolder, you'll see that no errors appear in the console. Sweet!

## Using FindObjectOfType

Add a new Action. Search `UnityEngine.Object` into the type picker and select `FindObjectOfType`. We can use our return value from the previous step, and with that we should be able to successfully find the first component in the scene (in this case our `PlayerMarker`!)

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

This method is going to allow us to pass in any component, and give us a path to it separated out by slashes.

Feed the return value from `FindObjectOfType` into `ObjectPath`. Since there's no way to cast `Object` to `Component` in UltEvents, you'll need the to use the Debug menu to feed it in.

> [!info] See [[Using GetComponent in UltEvents#Using GetComponent with methods that don't take a generic Component (THE RED)]] for info on exploiting the debug menu for this purpose!  

![[ObjectPathWithTheRed.png]]

The paths returned by `ObjectPath` look something like this:
- `Spawnable [0]/Art/Main`
- `ObjectPathTest/[0]/Grips/BoxGrip`

Or in our case with the Player Marker, it should look something like this in most of SLZ's scenes:
- `//-----ENVIRONMENT/Player Marker`

This is perfect! Now that we have an exact path to the player marker, we can feed it into `Transform.Find` to convert our path into a Transform, then parent underneath it to get the exact location of the Player Marker.

Before we do that though - we're going to need to add a `/` onto the start of our path. This is what tells `Transform.Find` to search relative to the *root of our scene*, rather than underneath whatever we're calling the method on. For example, we need `Spawnable [0]/Art/Main` to become `/Spawnable [0]/Art/Main`

We can achieve this by using `string.Format`. Feed the return value from ObjectPath into `string.Format`, and then type `/{0}`. This will cause `string.Format` to return what we input, replacing `{0}` with the provided value.

And after that, all we need to do is feed it into `Transform.Find`, parent to the Transform and then reset the local position to insure we're at `0, 0, 0` underneath the player marker with no offset. And there we have it!

The final logic:

![[FullLogic.png]]