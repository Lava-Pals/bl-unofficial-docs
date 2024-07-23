> [!CAUTION] This guide was written for Patch 3 and may contain outdated information. 

## Basic Setup

First, add a SpawnableCratePlacer with the Clipboard Lore crate. add the LoreClipboardProxy script, then simply fill it out! In the SpawnableCratePlacer script, add the OnPlaceEvent and call the `LoreClipboardProxy.Spawn()` method. And that's it, your clipboard should work in-game now!
## Color

If you want to change the color of specific sentences, as far as I know, the "Use Color" toggle doesn't do anything . Instead use [unity rich text](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html), an example of that would be: "`<color=blue>Some text here!</color>`".

Here's a basic setup:
![[ClipboardSetup.png]]

If you find mistakes or things I forgot to mention, please message me on discord (sonofforehead), or you can commit to the [``GitHub Repo``](https://github.com/Lava-Pals/bl-unofficial-docs)