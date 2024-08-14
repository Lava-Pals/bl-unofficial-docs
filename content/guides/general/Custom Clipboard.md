> [!CAUTION] This guide was written for Patch 3 and may contain outdated information. 

## Basic Setup

First, add a SpawnableCratePlacer with the Clipboard Lore crate. Add a LoreClipboardProxy script, then fill it out! In the SpawnableCratePlacer script, in the OnPlaceEvent and call the `LoreClipboardProxy.Spawn()` method. And that's it, your clipboard should work in-game now!
## Color

The "Use Color" toggle is non-functional. Instead, use [Unity's Rich Text](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html) to recolor text. For example: `<color=blue>Some text here!</color>`.

Here's a basic setup:

![[ClipboardSetup.png]]

If you find mistakes or things I forgot to mention, please message me on discord (sonofforehead), or you can commit to the [``GitHub Repo``](https://github.com/Lava-Pals/bl-unofficial-docs)