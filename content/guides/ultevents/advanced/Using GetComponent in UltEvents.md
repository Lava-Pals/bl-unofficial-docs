Using GetComponent and it's variants in UltEvents is fairly simple, although a little bit odd.

GetComponent can be used for multiple things - one example would be breaking a plunger and destroying the joint created by it. Let's get into it:
First, let's make the example I mentioned above. Here's how it would look like:

![[DestroyJoint.png]]

We're getting the component in the first event using [`GameObject.GetComponent(string type)`](https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html) - we don't need to get a type for this one.
Then, we just use [`Object.Destroy(Object obj)`](https://docs.unity3d.com/ScriptReference/Object.Destroy.html) to destroy the returned component.
This will get way more advanced in the following chapter.

## Using GetComponent with methods that don't take a generic Component (THE RED)

If you try to use the returned Component from the GetComponent method you would see that you literally can't.

![[CantUseGetComponent.png]]

There is a reason behind this though; although every component derives from `Component`, it's not it.
To solve this, we literally just tell it "do it anyways!". We do this by using the [[Debugger]] and setting the argument into a return value, and the `Int` to the place of the GetComponent event in the array. (Starts from 0).

![[TheRed.gif]]

## Using GetComponent variants

Using other types of `GetComponent` (e.g [`GetComponentInChildren`](https://docs.unity3d.com/ScriptReference/GameObject.GetComponentInChildren.html), [`GetComponentInParent`](https://docs.unity3d.com/ScriptReference/GameObject.GetComponentInParent.html) etc etc..) is a bit different since you have to get a `Type`. It's fairly straight forward, you just need to run `System.Type.GetType(string)`. It should look something like this:

![[GetComponentVariant.png]]

That's all for now!