Make sure you have the [`BoneLab Internal Pallet`](https://cdn.discordapp.com/attachments/1029149396056686602/1192579758903545897/BONELAB_Internal_Pallet.unitypackage?ex=66579d73&is=66564bf3&hm=46fe3caf382d52d955cdbc82044bc59a5dc494305217924ecf88548df081128e&) installed for this guide.
## Basic Setup
First, add a spawnable placer with the Clipboard Lore crate. add the LoreClipboardProxy script, then simply fill it out! In the SpawnableCratePlacer script, add the OnPlaceEvent and call the LoreClipboardProxy.Spawn method. And that's it, your clipboard should work in-game now!
## Color
If you're wanting to change the color of specific sentences, as far as I know, the "Use Color" toggle doesn't do anything. Instead use rich text, an example of that would be putting "<color=#1a2b3c>Main Text Here" before your sentence.

Here's an example if you're having trouble:
![[clipboardexample.png]]

If anybody finds mistakes or things I forgot to mention, please message me on discord (sonofforehead), or you can commit to the [``GitHub Repo``](https://github.com/Lava-Pals/bl-unofficial-docs)