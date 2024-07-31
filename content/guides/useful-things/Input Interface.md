## Resources

- [📂 Prefabs for this guide are available on the repository!](https://github.com/Lava-Pals/bl-unofficial-docs/tree/main/resources/prefabs/Input%20Interface)
	- [`InputInterface.prefab`](https://github.com/Lava-Pals/bl-unofficial-docs/blob/main/resources/prefabs/Input%20Interface/InputInterface.prefab)


A system that exposes the `BaseController` on the `RigManager` and letting you access inputs you normally can't.

The system basically switches the UltEvent call's target to the actual `BaseController` from the `RigManager` instead of a dummy one. 
## Usage
Reference your grip in the `Simple Grip Events`, located on the Simple Grip Events object.

![[SGE Reference.png]]

Then, reference your grip in the first call on the UltEvent holder that's located on the OnGrab object. 

![[UltEvent Reference.png]]

Now that's done, and the system should work. Next up is actually using the given input.

### Using the given input
To get and use the input from the `BaseController`, you'd want to go to the ButtonListener object.
You can see there's already one event, and it's referencing a dummy `BaseController` - you can call any method on it, for example `GetThumbStick` to get a value from it, a bool if the thumbstick is down or not in this case.

You can apply that bool onto an object using `GameObject.SetActive` and making the bool reference the outputted value from the method called above. Make sure you have it disabled in editor.
You can use `LifeCycleEvents` to know when the object is enabled or disabled (e.g the object will get enabled once the thumbstick is pressed down and disabled once not pressed).

> [!WARNING] Make sure the call that's referencing the `BaseController` is the first one, or else things are gonna break!