# Introduction
In this guide I'm going to go over what does what in each component on the wheel Game Objects you made in the [[Vehicle Guide]], if you made your own vehicle separate from the guide, this should still apply! 

## Configurable Joints
I'm not going to go into detail for every option in the Configurable Joint component because there's already [Unity docs](https://docs.unity3d.com/Manual/class-ConfigurableJoint.html) for them, just know everything I went over in the [[Vehicle Guide]] is required to make the wheels *work*. You can mess with anything I didn't go over.

## Test Contact Mod
Test Contact Mod is used for *suspension*, the values are pretty simple and self explanatory, but I'll explain them anyway.
- **The Rigidbody and Collider**: These need to be set to each individual wheels collider and Rigidbody, so make sure you don't drag it in with all wheels selected.
- **Max Depth**: This is the value that decides how far the wheel can go, keep this number VERY low, the GoKart uses 0.04, if you have an average real life sized car, maybe do 0.2? I haven't messed with this too much, if you want to get it exactly how you want I suggest installing [Unity Explorer](https://github.com/sinai-dev/UnityExplorer) and adjusting values there. 
- **Min Force**: This and **Max Force** pretty much explain themselves, minimum force should be a lower number, like the GoKarts is 10.
- **Max Force**: Keep this as a higher number generally, the GoKart uses 10000000. It's kind of hard for me to figure out how these values work, so I'd suggest just playing around with them based off the GoKart until you got what you want.

## Collision Stay Sensor
This component focus' on making the vehicle *drift*, it should be on each wheel, as it's required for the ATV script.
Component options:
- **Is Grounded & Ungrounded This Frame**: Both these bools change depending on if the vehicle is on the ground or not, there is no reason to change these, but you could use them with [[guides/ultevents]]!
- **Pressure Normal**: This determines the sensitivity of the drift, you'll need higher numbers the heavier your car + wheels are, for reference, the GoKart has it set to 0 5 0, with the vehicles root weight being 120.
- **Pressure Point**: This seems to act as the *audio* sensitivity, the higher the numbers the easier it'll play your skid sound effect on the ATV script, try to keep this very low, even 0 0 0 works fine and is what the GoKart uses.
- **As far as I can tell**, the rest of the values are unimportant, as they also change in game so it would be useless to set them. Please message me on discord if you find out there is something else they do. (sonofforehead)