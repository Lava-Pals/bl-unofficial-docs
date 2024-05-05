UltEvents are the most powerful way (...and the only way) to make functional and advanced items. What are they?
Before we start, make sure to take some time and read their docs, which can be found [here](https://kybernetik.com.au/ultevents/).

UltEvents is a custom Unity Package that has been created to supersede Unity's built-in Unity Events with a couple quality-of-life features. Their main use case originally is for high-level logic that keeps the code of different components decoupled - but in the BONELAB modding space we use it like a very dumbed down visual scripting system.

UltEvents are definitely not intended for how we as modders use them, not in the slightest - to put it simply, we are abusing the ever living shit out of them.

You can read about the differences between UltEvents and UnityEvents [here](https://kybernetik.com.au/ultevents/docs/ult-vs-unity/).

In the last two years, we've managed to find a lot of UltEvents hacks, tricks and unintended behaviours.

## Time for the basics!

If you really wanna understand, open unity - and make a new prefab. Add an UltEvent Holder script to an object; copy the guide 1 to 1, it'll help you understand the workflow.



![[EventSetup.png]]
The image above is a good reference when talking about events. For example we can say "set the method to x, and the target to object y".

Say... you wanna change the active state of an object. Click the plus icon to add an event to the list. Drag the desired object and set it as your target, then open the method menu, and locate ``void SetActive``. You can modify the bool value to your needs.

As you can see, you need to know your way around unity's API to know what you're doing.

#### And that's the end of the introduction! Next up - more advanced logic. We're going to be making a counter.